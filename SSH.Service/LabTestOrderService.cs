using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recipe.Common.Helper;
using Recipe.Core.Base.Generic;
using SSH.Common.Helper;
using SSH.Core.Constant;
using SSH.Core.DTO;
using SSH.Core.Entity;
using SSH.Core.Enum;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;
using SSH.Core.IService;

namespace SSH.Service
{
    public class LabTestOrderService : Service<ILabTestOrderRepository, LabTestOrder, LabTestOrderDTO, int>, ILabTestOrderService
    {
        private ISSHUnitOfWork unitOfWork;
        private IExceptionHelper exceptionHelper;
        private ISSHRequestInfo requestInfo;
        private ILabInvoiceService labInvoiceService;

        public LabTestOrderService(ISSHUnitOfWork unitOfWork, IExceptionHelper exceptionHelper, ISSHRequestInfo requestInfo, ILabInvoiceService labInvoiceService) 
            : base(unitOfWork, unitOfWork.LabTestOrderRepository)
        {
            this.unitOfWork = unitOfWork;
            this.exceptionHelper = exceptionHelper;
            this.requestInfo = requestInfo;
            this.labInvoiceService = new LabInvoiceService(unitOfWork, exceptionHelper, requestInfo);
        }

        #region DEMO OF INSERTION OF MASTER DETAIL
        //public override async Task<LabTestOrderDTO> CreateAsync(LabTestOrderDTO dtoObject)
        //{
        // Tayyab - >Example

        //First your checks if required before insert

        //------------------------------------------------------
        //if (dtoObjects == null)
        //{
        //    this.exceptionHelper.ThrowAPIException(string.Format(Message.NotFound, "Lab Test Order"));
        //}

        //if (dtoObjects.DoctorId != null)
        //{
        //    this.exceptionHelper.ThrowAPIException(string.Format(Message.NotFound, "Doctor"));
        //}
        //------------------------------------------------------

        // After your checks
        // It will insert both (master  and detail) because i have mention mapping on Dto
        //var labTestOrder = await base.CreateAsync(dtoObject);
        // After insert it will return you complete labTestOrder object with Ids you can find all things on labTestOrder variable... because i have mapped 
        // it on insert and on Get

        // Now you can again make checks if required... these checks will be after insertion
        //if (labTestOrder != null)
        //{
        //    // Like this
        //}

        // Got it?
        // Yes

        // you can return both variables
        // 1. dtoObject
        // 2. labTestOrder

        // Because both are DTOs . It means both are same, so we can return anyone.?

        // Yes, it means dtoObject is coming from front end and labTestOrder variable is after insert, so dtoObject has no Id value but labTestOrder variable has 
        // complete data! got it?
        // Yes Whole process i got.

        // Ok :)
        //return labTestOrder;
        //}
        #endregion

        #region EXPLANATION LOGIC OF CreateAsync
        /* Order Place Logic: 
         * 1. Patient is Walk-in: Bill Type: PayNow; Payment mode: Any.
         * 2. Patient is In-Patient: Bill Type: PayLater; Payment mode: Any.
         * 3. Patient is In-Patient: Bill Type: PayNow - Then Follow #1; Payment mode: Any.
         * 
         * Order Details Place Logic:
         * 1. Required: Test ids,Test unit Price; End time: Put when status=Dispatch (Update); Urgent: each test can/cannot be;
         * IsOutSource: (IF Yes) No Unit price, Status=Initiate, SampleCollected & Dispatched, No Doctor Id, Has outSource Hospital Name;
         * 2. Required: Test ids,Test unit Price; End time: Put when status=Dispatch (Update); Urgent: each test can/cannot be; 
         * IsOutSource: (IF Yes) No Unit price, Status=Initiate & Dispatched, No Doctor Id, Has outSource Hospital Name;
         * 3. Required: Test ids,Test unit Price; #1 Point Follow
         * 
         * Invoice Place Logic: 
         * 1. Required: Income Group id, Order Id, Rate sheet id; Total Amount: Collection of unit price tests; Recieved Amount:= Total Amount; Due Amount: none; 
         * IF Rate Sheet: Calculate on Recieved amount then put in received amount; 
         * 2. Required: Income Group id, Order Id, Rate sheet id; Total Amount: Collection of unit price tests; Recieved Amount:= Any Amount/Full Amount; Due Amount: None/IF remaining;
         * Bill Type:PayLater: No Rate Sheet will Apply; IF Rate Sheet Apply & Calculate on Recieved amount then put in received amount;
         * 3. Required: Income Group id, Order Id, Rate sheet id; #1 Point Follow.
         * 
         * * Invoice Detail Place Logic: 
         * 1. Required: Invoice id, Test id; Test Unit Price: Collection of unit price tests; 
         */
        #endregion

        public async override Task<LabTestOrderDTO> CreateAsync(LabTestOrderDTO dtoObject)
        {
           if (dtoObject == null)
            {
                this.exceptionHelper.ThrowAPIException(string.Format(Message.NotFound, "Lab test order not provided"));
            }
            else if (dtoObject != null && dtoObject.LabTestOrderDetailDto.Count == 0 && dtoObject.IncomeGroupId != 0)
            {
                // If Only Lab Order Master Is Called.
                dtoObject = await base.CreateAsync(dtoObject);
            }
            else if (dtoObject != null && dtoObject.LabTestOrderDetailDto.Count > 0 && dtoObject.IncomeGroupId != 0)
            {
                // Works when Form contains Master & Detail.

                LabInvoiceDTO labInvoicedto = new LabInvoiceDTO();
                labInvoicedto.LabInvoiceDetaildto = new List<LabInvoiceDetailDTO>();
                labInvoicedto.TotalAmount = 0;
                labInvoicedto.ReceivedAmount = dtoObject.ReceivedAmount;
                labInvoicedto.IncomeGroupId = dtoObject.IncomeGroupId;
                labInvoicedto.DueAmount = 0;
                labInvoicedto.Tax = 0;

                // Validations
                if ((dtoObject.BillType != "PayLater" && dtoObject.BillType != "PayNow") ||
                    (dtoObject.PatientType != "WalkIn" && dtoObject.PatientType != "InPatient") ||
                    (dtoObject.PaymentMode != "Cash" && dtoObject.PaymentMode != "Card") ||
                    (dtoObject.DoctorId != 0 && (!string.IsNullOrEmpty(dtoObject.OutSourceDoctorName) || !string.IsNullOrEmpty(dtoObject.OutSourceHospitalName))))
                {
                    this.exceptionHelper.ThrowAPIException(string.Format(Message.NotFound, "Wrong entry provided in lab test order"));
                }

                // Detail List I.E Tests
                foreach (var orderdetailRec in dtoObject.LabTestOrderDetailDto)
                {
                    // When outsource could not enter in-hospital doctor.
                    if ((orderdetailRec.IsOutSource == true && orderdetailRec.DoctorId != null && orderdetailRec.DoctorId != 0) ||
                        (orderdetailRec.DoctorId != 0 && !string.IsNullOrEmpty(orderdetailRec.OutSourceHospitalName)))
                    {
                        this.exceptionHelper.ThrowAPIException(string.Format(Message.NotFound, "Wrong entry provided in lab order test details"));
                    }

                    labInvoicedto.TotalAmount += orderdetailRec.TestUnitPrice;   // Collecting test unit price into total amount
                    labInvoicedto.LabInvoiceDetaildto.Add(new LabInvoiceDetailDTO() { LabInvoiceId = 0, LabTestBuilderId = orderdetailRec.LabTestBuilderId, TestUnitPrice = orderdetailRec.TestUnitPrice });
                }

                // RATE SHEET Working: Perform Increment Or decrement on total Amount...Rate Sheet Can/ cannot be implement.
                if (dtoObject.RateSheetdto.Increment == 0 && dtoObject.RateSheetdto.Discount != 0 && dtoObject.RateSheetdto.Id != 0)
                {
                    labInvoicedto.TotalAmount = labInvoicedto.TotalAmount - (labInvoicedto.TotalAmount * (dtoObject.RateSheetdto.Discount / 100));  // Discount
                    dtoObject.RateSheetId = dtoObject.RateSheetdto.Id;
                }
                else if (dtoObject.RateSheetdto.Increment != 0 && dtoObject.RateSheetdto.Discount == 0 && dtoObject.RateSheetdto.Id != 0)
                {
                    labInvoicedto.TotalAmount = labInvoicedto.TotalAmount + (labInvoicedto.TotalAmount * (dtoObject.RateSheetdto.Increment / 100));  // Increment
                    dtoObject.RateSheetId = dtoObject.RateSheetdto.Id;
                }

                if (labInvoicedto.ReceivedAmount > labInvoicedto.TotalAmount)
                {
                    this.exceptionHelper.ThrowAPIException(string.Format(Message.NotFound, "Wrong entry provided in lab test billing"));
                }

                // Is Bill Fully Paid Or Not.
                labInvoicedto.IsBillPaid = (labInvoicedto.TotalAmount == labInvoicedto.ReceivedAmount) ? true : false;

                labInvoicedto.DueAmount = (labInvoicedto.IsBillPaid == false) ? labInvoicedto.TotalAmount - labInvoicedto.ReceivedAmount : 0;

                // All Set LAB TEST ORDER master & detail, Now Insert
                dtoObject = await base.CreateAsync(dtoObject);

                //labInvoicedto = dtoObject.LabInvoicedto;
                if (dtoObject != null)
                {
                    labInvoicedto.LabTestOrderId = dtoObject.Id;    // Lab Order Id i.e Newly created.
                    labInvoicedto = await this.labInvoiceService.CreateAsync(labInvoicedto);    // Invoice Master Detail Call
                }
            }
            else
            {
                this.exceptionHelper.ThrowAPIException(string.Format(Message.NotFound, "Fill out required entries"));
            }

            return dtoObject;
        }

        //public async override Task<LabTestOrderDTO> CreateAsync(LabTestOrderDTO dtoObject)
        //{
        //    LabTestOrderDTO labTestOrderdto = new LabTestOrderDTO();
        //    LabInvoiceDTO labinvoiceDTO = new LabInvoiceDTO();
        //    labinvoiceDTO.LabInvoiceDetaildto = new List<LabInvoiceDetailDTO>();

        //    if (dtoObject == null)
        //    {
        //        this.exceptionHelper.ThrowAPIException(string.Format(Message.NotFound, "Lab test order not provided"));
        //    }
        //    else if (dtoObject != null && dtoObject.LabTestOrderDetailDto == null && dtoObject.IncomeGroupDTO == null)
        //    {
        //        // If Only Lab Order Master Is Called.
        //        labTestOrderdto = await base.CreateAsync(dtoObject);
        //    }
        //    else if (dtoObject != null && dtoObject.LabTestOrderDetailDto != null && dtoObject.IncomeGroupDTO != null)
        //    {
        //        // Works when Form contains Master & Detail.
        //        labinvoiceDTO.TotalAmount = 0;
        //        labinvoiceDTO.ReceivedAmount = 0;
        //        labinvoiceDTO.DueAmount = 0;

        //        foreach (var labTestOrderDetailList in dtoObject.LabTestOrderDetailDto)
        //        {
        //            labTestOrderDetailList.TestStatus = LabTestStatus.Initiate;
        //            labinvoiceDTO.TotalAmount += labTestOrderDetailList.TestUnitPrice;   // Collecting test unit price into total amount (invoice)
        //            // When outsource could not enter in-hospital doctor.
        //            if (labTestOrderDetailList.IsOutSource == true && labTestOrderDetailList.DoctorId != null && labTestOrderDetailList.DoctorId != 0)
        //            {
        //                this.exceptionHelper.ThrowAPIException(string.Format(Message.NotFound, "Out source test could not contain in-hospital doctor"));
        //            }
        //            // Fetching Test data for Invoice Details
        //            // ================ Invoice Detail DTO : INVOICE DETAIL WORKING
        //            labinvoiceDTO.LabInvoiceDetaildto.Add(new LabInvoiceDetailDTO() { Id = 0, LabInvoiceId = 0, LabTestBuilderId = labTestOrderDetailList.LabTestBuilderId, TestUnitPrice = labTestOrderDetailList.TestUnitPrice });
        //            // ================ Invoice Detail DTO : INVOICE DETAIL WORKING
        //        }

        //        // All Set LAB TEST ORDER master & detail, Now Insert
        //        labTestOrderdto = await base.CreateAsync(dtoObject);

        //        // ================ INVOICE WORKING : Picking required DTO from Order into Invoice DTO 
        //        labinvoiceDTO.LabTestOrderId = labTestOrderdto.Id;
        //        labinvoiceDTO.IncomeGroupId = labTestOrderdto.IncomeGroupDTO.Id;
        //        labinvoiceDTO.ReceivedAmount = labTestOrderdto.ReceivedAmount;
        //        labinvoiceDTO.DueAmount = labinvoiceDTO.TotalAmount - labTestOrderdto.ReceivedAmount;

        //        labinvoiceDTO.IsBillPaid = labinvoiceDTO.DueAmount == 0 ? true : false;

        //        // RATE SHEET Working : Perform Increment Or decrement on total Amount... Rate Sheet Can/cannot be implement.
        //        labinvoiceDTO.RateSheetId = null;

        //        if (labTestOrderdto.RateSheetdto.Increment == 0 && labTestOrderdto.RateSheetdto.Discount != 0)
        //        {
        //            labinvoiceDTO.TotalAmount = labinvoiceDTO.TotalAmount - (labinvoiceDTO.TotalAmount * (labTestOrderdto.RateSheetdto.Discount / 100));  // Discount
        //            labinvoiceDTO.RateSheetId = labTestOrderdto.RateSheetdto.Id;
        //        }
        //        else if (labTestOrderdto.RateSheetdto.Increment != 0 && labTestOrderdto.RateSheetdto.Discount == 0)
        //        {
        //            labinvoiceDTO.TotalAmount = labinvoiceDTO.TotalAmount + (labinvoiceDTO.TotalAmount * (labTestOrderdto.RateSheetdto.Discount / 100));  // Increment
        //            labinvoiceDTO.RateSheetId = labTestOrderdto.RateSheetdto.Id;
        //        }
        //        // ================ INVOICE WORKING

        //        // All Set LAB INVOICE master & detail, Now Insert
        //        labinvoiceDTO = await this.labInvoiceService.CreateAsync(labinvoiceDTO);

        //        //if (dtoObject.PatientType == "WalkIn" && dtoObject.BillType == "PayNow")
        //        //{
        //        //    // PatientType = Walk-In Patient Method Call
        //        //}
        //        //else if (dtoObject.PatientType == "InPatient" && dtoObject.BillType == "PayNow")
        //        //{
        //        //    // PatientType = Walk-In Patient Method Call
        //        //}
        //        //else if (dtoObject.PatientType == "InPatient" && dtoObject.BillType == "PayLater")
        //        //{
        //        //    // PatientType = In-Patient Method Call
        //        //}
        //    }
        //    else
        //    {
        //        this.exceptionHelper.ThrowAPIException(string.Format(Message.NotFound, "Lab test order could not create"));
        //    }

        //    return labTestOrderdto;
        //}
    }
}
