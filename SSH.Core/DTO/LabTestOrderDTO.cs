using System;
using System.Collections.Generic;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class LabTestOrderDTO : DTO<LabTestOrder, int>
    {
        public int PatientId { get; set; }

        // Walkin/In-Patient
        public string PatientType { get; set; }

        // Cash/Card
        public string PaymentMode { get; set; }

        // Pay Now/ Pay Later
        public string BillType { get; set; }

        public int? DoctorId { get; set; }

        public string OutSourceDoctorName { get; set; }

        public string OutSourceHospitalName { get; set; }

        public int? RateSheetId { get; set; }

        public RateSheetDTO RateSheetdto { get; set; }

        public IList<LabTestOrderDetailDTO> LabTestOrderDetailDto { get; set; }

        // Invoice Data 
        public double ReceivedAmount { get; set; }

        public int IncomeGroupId { get; set; }

        public override void ConvertFromEntity(LabTestOrder entity)
        {
            base.ConvertFromEntity(entity);
            this.PatientType = entity.PatientType;
            this.PaymentMode = entity.PaymentMode;
            this.BillType = entity.BillType;
            this.OutSourceDoctorName = entity.OutSourceDoctorName;
            this.OutSourceHospitalName = entity.OutSourceHospitalName;
            this.DoctorId = entity.DoctorId != null ? entity.DoctorId : 0;
            this.PatientId = entity.PatientId;
            this.RateSheetId = entity.RateSheetId;
            this.LabTestOrderDetailDto = entity.LabTestOrderDetail != null ? LabTestOrderDetailDTO.ConvertEntityListToDTOList<LabTestOrderDetailDTO>(entity.LabTestOrderDetail) : null;
        }

        public override LabTestOrder ConvertToEntity(LabTestOrder entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.PatientType = this.PatientType;
            entity.PaymentMode = this.PaymentMode;
            entity.BillType = this.BillType;
            entity.OutSourceDoctorName = this.OutSourceDoctorName;
            entity.OutSourceHospitalName = this.OutSourceHospitalName;
            entity.DoctorId = (this.DoctorId == 0 || this.DoctorId == null) ? null : this.DoctorId;
            entity.PatientId = this.PatientId;
            entity.RateSheetId = this.RateSheetId;
            entity.LabTestOrderDetail = this.LabTestOrderDetailDto != null ? LabTestOrderDetailDTO.ConvertDTOListToEntity(this.LabTestOrderDetailDto) : null;
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastModifiedOn = DateTime.UtcNow;

            return entity;
        }
    }
}