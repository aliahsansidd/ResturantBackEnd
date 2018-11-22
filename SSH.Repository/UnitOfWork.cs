using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using Recipe.Core.Base.Interface;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class UnitOfWork : ISSHUnitOfWork
    {
        private readonly ISSHRequestInfo sshRequestInfo;
        private readonly IUserRepository userRepository;
        private readonly IAuditRepository auditRepository;
        private readonly IEmailNotificationRepository emailNotificationRepository;
        private readonly IOTPRepository otpRepository;
        private readonly IExceptionHelper exceptionHelper;
        private readonly ILOVRepository lovRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IRequestInfo requestInfo;
        private readonly IUserRolePermissionRepository userRolePermissionRepository;
        private readonly IPermissionRepository permissionRepository;
        private readonly IPushNotificationRepository pushNotificationRepository;
        private readonly IUserSessionRepository userSessionRepository;
        private readonly IPatientRepository patientRepository;
        private readonly IDoctorRepository doctorRepository;
        private readonly IDoctorCategoryRepository doctorCategoryRepository;
        private readonly IDoctorOPDRepository doctorOPDRepository;
        private readonly IDoctorOpdDateRepository doctorOpdDateRepository;
        private readonly IOPDRepository opdRepository;
        private readonly IConsultancyTimingRepository consultancyTimingRepository;
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IBirthRepository birthRepository;
        private readonly IDeathRepository deathRepository;
        private readonly IBuildingMaterialCategoryRepository buildingMaterialCategoryRepository;
        private readonly IBuildingMaterialRepository buildingMaterialRepository;
        private readonly IWardCategoryRepository wardCategoryRepository;
        private readonly IRoomRepository roomRepository;
        private readonly IBedRepository bedRepository;
        private readonly IBedAllocationRepository bedAllocationRepository;
        private readonly ILabDepartmentRepository labDepartmentRepository;
        private readonly ILabDepartmentServicesRepository labDepartmentServicesRepository;
        private readonly IRateSheetRepository rateSheetRepository;
        private readonly ILabTestingUnitRepository labTestingUnitRepository;
        private readonly ITestParameterRepository testParameterRepository;
        private readonly ILabTestBuilderRepository labTestBuilderRepository;
        private readonly ILabTestByValueRepository labTestByValueRepository;
        private readonly ILabTestByEditorRepository labTestByEditorRepository;
        private readonly ILabTestTemplateRepository labTestTemplateRepository;
        private readonly IOPDRegistrationRepository opdRegistrationRepository;
        private readonly ILabTestOrderRepository labTestOrderRepository;
        private readonly ILabTestOrderDetailRepository labTestOrderDetailRepository;
        private readonly ICompanyAccountLevelRepository companyAccountLevelRepository;
        private readonly ICompanyAccountRepository companyAccountRepository;
        private readonly IIncomeGroupRepository incomeGroupRepository;
        private readonly ILabInvoiceRepository labInvoiceRepository;
        private readonly ILabInvoiceDetailRepository labInvoiceDetailRepository;
        private readonly ILabSampleTypeRepository labSampleTypeRepository;
        private readonly ILabSampleRepository labSampleRepository;
        private readonly ILabTestSampleRepository labTestSampleRepository;
        private readonly IInventoryCategoryRepository inventoryCategoryRepository;
        private readonly IInventoryItemRepository inventoryItemRepository;
        private readonly ILabOutSourceRepository labOutSourceRepository;
        private readonly IDoctorOPDTimeSlotRepository doctorOPDTimeSlotRepository;
        private readonly ILabTestInventoryAllocationRepository labTestInventoryAllocationRepository;
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IProductChemicalRepository productChemicalRepository;
        private readonly IProductMeasurementUnitRepository productMeasurementUnitRepository;
        private readonly IProductTypeRepository productTypeRepository;
        private readonly IProductUnitRepository productUnitRepository;
        private readonly IBrandRepository brandRepository;
        private readonly IRacksRepository racksRepository;
        private readonly ICatastrophicEventRepository catastrophicEventRepository;
        private readonly IAccidentAndEmergencyRepository accidentAndEmergencyRepository;
        private readonly IBroughterDetailsRepository broughterDetailsRepository;
        private readonly IAmbulanceDetailsRepository ambulanceDetailsRepository;
        private readonly IBuildingFloorRepository buildingFloorRepository;
        private readonly IClientGroupRepository clientGroupRepository;
        private readonly IClientTypeRepository clientTypeRepository;
        private readonly ICPTCategoryRepository cptCategoryRepository;
        private readonly IGroupOfCompaniesRepository groupOfCompaniesRepository;
        private readonly IOrganizationRepository organizationRepository;
        private readonly ILisenceRepository lisenceRepository;
        private readonly IOrganizationalDivisionRepository organizationalDivisionRepository;
        private readonly IOrganizationalDivisionDepartmentRepository organizationalDivisionDepartmentRepository;
        private readonly IAmbulanceRepository ambulanceRepository;

        public UnitOfWork(
            ISSHRequestInfo sshRequestInfo,
            IUserRepository userRepository,
            IAuditRepository auditRepository,
            IEmailNotificationRepository emailNotificationRepository,
            IOTPRepository otpRepository,
            IExceptionHelper exceptionHelper,
            ILOVRepository lovRepository,
            ISSHRequestInfo requestInfo,
            IUserRolePermissionRepository userRolePermissionRepository,
            IRoleRepository roleRepository,
            IPermissionRepository permissionRepository,
            IPushNotificationRepository pushNotificationRepository,
            IUserSessionRepository userSessionRepository,
            IPatientRepository patientRepository,
            IDoctorRepository doctorRepository,
            IDoctorCategoryRepository doctorCategoryRepository,
            IDoctorOPDRepository doctorOPDRepository,
            IDoctorOpdDateRepository doctorOpdDateRepository,
            IOPDRepository opdRepository,
            IConsultancyTimingRepository consultancyTimingRepository,
            IAppointmentRepository appointmentRepository,
            IBirthRepository birthRepository,
            IDeathRepository deathRepository,
            IBuildingMaterialCategoryRepository buildingMaterialCategoryRepository,
            IBuildingMaterialRepository buildingMaterialRepository,
            IWardCategoryRepository wardCategoryRepository,
            IRoomRepository roomRepository,
            IBedRepository bedRepository,
            IBedAllocationRepository bedAllocationRepository,
            ILabDepartmentRepository labDepartmentRepository,
            ILabDepartmentServicesRepository labDepartmentServicesRepository,
            IRateSheetRepository rateSheetRepository,
            ILabTestingUnitRepository labTestingUnitRepository,
            ITestParameterRepository testParameterRepository,
            ILabTestBuilderRepository labTestBuilderRepository,
            ILabTestByValueRepository labTestByValueRepository,
            ILabTestByEditorRepository labTestByEditorRepository,
            ILabTestTemplateRepository labTestTemplateRepository,
            IOPDRegistrationRepository opdRegistrationRepository,
            ILabTestOrderRepository labTestOrderRepository,
            ILabTestOrderDetailRepository labTestOrderDetailRepository,
            ICompanyAccountLevelRepository companyAccountLevelRepository,
            ICompanyAccountRepository companyAccountRepository,
            IIncomeGroupRepository incomeGroupRepository,
            ILabInvoiceRepository labInvoiceRepository,
            ILabInvoiceDetailRepository labInvoiceDetailRepository,
            ILabSampleTypeRepository labSampleTypeRepository,
            ILabSampleRepository labSampleRepository,
            ILabTestSampleRepository labTestSampleRepository,
            IInventoryCategoryRepository inventoryCategoryRepository,
            IInventoryItemRepository inventoryItemRepository,
            ILabOutSourceRepository labOutSourceRepository,
            IDoctorOPDTimeSlotRepository doctorOPDTimeSlotRepository,
            ILabTestInventoryAllocationRepository labTestInventoryAllocationRepository,
            IProductCategoryRepository productCategoryRepository,
            IProductChemicalRepository productChemicalRepository,
            IProductMeasurementUnitRepository productMeasurementUnitRepository,
            IProductTypeRepository productTypeRepository,
            IProductUnitRepository productUnitRepository,
            IBrandRepository brandRepository,
            IRacksRepository racksRepository,
            IBuildingFloorRepository buildingFloorRepository,
            ICatastrophicEventRepository catastrophicEventRepository,
            IAccidentAndEmergencyRepository accidentAndEmergencyRepository,
            IBroughterDetailsRepository broughterDetailsRepository,
            IAmbulanceDetailsRepository ambulanceDetailsRepository,
            IClientGroupRepository clientGroupRepository,
            IClientTypeRepository clientTypeRepository,
            ICPTCategoryRepository cptCategoryRepository,
            IGroupOfCompaniesRepository groupOfCompaniesRepository,
            IOrganizationRepository organizationRepository,
            ILisenceRepository lisenceRepository,
            IOrganizationalDivisionRepository organizationalDivisionRepository,
            IOrganizationalDivisionDepartmentRepository organizationalDivisionDepartmentRepository,
            IAmbulanceRepository ambulanceRepository)
        {
            this.sshRequestInfo = sshRequestInfo;
            this.userRepository = userRepository;
            this.auditRepository = auditRepository;
            this.exceptionHelper = exceptionHelper;
            this.exceptionHelper = exceptionHelper;
            this.emailNotificationRepository = emailNotificationRepository;
            this.otpRepository = otpRepository;
            this.lovRepository = lovRepository;
            this.roleRepository = roleRepository;
            this.requestInfo = requestInfo;
            this.userRolePermissionRepository = userRolePermissionRepository;
            this.permissionRepository = permissionRepository;
            this.pushNotificationRepository = pushNotificationRepository;
            this.userSessionRepository = userSessionRepository;
            this.patientRepository = patientRepository;
            this.doctorRepository = doctorRepository;
            this.doctorCategoryRepository = doctorCategoryRepository;
            this.doctorOPDRepository = doctorOPDRepository;
            this.doctorOpdDateRepository = doctorOpdDateRepository;
            this.opdRepository = opdRepository;
            this.consultancyTimingRepository = consultancyTimingRepository;
            this.appointmentRepository = appointmentRepository;
            this.birthRepository = birthRepository;
            this.deathRepository = deathRepository;
            this.buildingMaterialCategoryRepository = buildingMaterialCategoryRepository;
            this.buildingMaterialRepository = buildingMaterialRepository;
            this.wardCategoryRepository = wardCategoryRepository;
            this.roomRepository = roomRepository;
            this.bedRepository = bedRepository;
            this.bedAllocationRepository = bedAllocationRepository;
            this.labDepartmentRepository = labDepartmentRepository;
            this.labDepartmentServicesRepository = labDepartmentServicesRepository;
            this.rateSheetRepository = rateSheetRepository;
            this.labTestingUnitRepository = labTestingUnitRepository;
            this.testParameterRepository = testParameterRepository;
            this.labTestBuilderRepository = labTestBuilderRepository;
            this.labTestByValueRepository = labTestByValueRepository;
            this.labTestTemplateRepository = labTestTemplateRepository;
            this.opdRegistrationRepository = opdRegistrationRepository;
            this.labTestOrderRepository = labTestOrderRepository;
            this.labTestOrderDetailRepository = labTestOrderDetailRepository;
            this.companyAccountLevelRepository = companyAccountLevelRepository;
            this.companyAccountRepository = companyAccountRepository;
            this.incomeGroupRepository = incomeGroupRepository;
            this.labInvoiceRepository = labInvoiceRepository;
            this.labInvoiceDetailRepository = labInvoiceDetailRepository;
            this.labSampleTypeRepository = labSampleTypeRepository;
            this.labSampleRepository = labSampleRepository;
            this.labTestByEditorRepository = labTestByEditorRepository;
            this.inventoryCategoryRepository = inventoryCategoryRepository;
            this.inventoryItemRepository = inventoryItemRepository;
            this.labOutSourceRepository = labOutSourceRepository;
            this.doctorOPDTimeSlotRepository = doctorOPDTimeSlotRepository;
            this.labTestInventoryAllocationRepository = labTestInventoryAllocationRepository;
            this.labTestSampleRepository = labTestSampleRepository;
            this.productCategoryRepository = productCategoryRepository;
            this.productChemicalRepository = productChemicalRepository;
            this.productMeasurementUnitRepository = productMeasurementUnitRepository;
            this.productTypeRepository = productTypeRepository;
            this.productUnitRepository = productUnitRepository;
            this.brandRepository = brandRepository;
            this.racksRepository = racksRepository;
            this.catastrophicEventRepository = catastrophicEventRepository;
            this.accidentAndEmergencyRepository = accidentAndEmergencyRepository;
            this.broughterDetailsRepository = broughterDetailsRepository;
            this.ambulanceDetailsRepository = ambulanceDetailsRepository;
            this.buildingFloorRepository = buildingFloorRepository;
            this.clientGroupRepository = clientGroupRepository;
            this.clientTypeRepository = clientTypeRepository;
            this.cptCategoryRepository = cptCategoryRepository;
            this.groupOfCompaniesRepository = groupOfCompaniesRepository;
            this.organizationRepository = organizationRepository;
            this.lisenceRepository = lisenceRepository;
            this.organizationalDivisionRepository = organizationalDivisionRepository;
            this.organizationalDivisionDepartmentRepository = organizationalDivisionDepartmentRepository;
            this.ambulanceRepository = ambulanceRepository;
        }

        public DbContext DBContext
        {
            get
            {
                return this.sshRequestInfo.Context;
            }
        }

        public ISSHRequestInfo SSHRequestInfo
        {
            get
            {
                return this.sshRequestInfo;
            }
        }
        
        public IUserRepository UserRepository
        {
            get
            {
                return this.userRepository;
            }
        }

        public IPatientRepository PatientRepository
        {
            get
            {
                return this.patientRepository;
            }
        }

        public IUserSessionRepository UserSessionRepository
        {
            get
            {
                return this.userSessionRepository;
            }
        }

        public IUserRolePermissionRepository UserRolePermissionRepository
        {
            get
            {
                return this.userRolePermissionRepository;
            }
        }

        public IAuditRepository AuditRepository
        {
            get
            {
                return this.auditRepository;
            }
        }

        public IEmailNotificationRepository EmailNotificationRepository
        {
            get
            {
                return this.emailNotificationRepository;
            }
        }

        public IOTPRepository OTPRepository
        {
            get
            {
                return this.otpRepository;
            }
        }
        
        public ILOVRepository LOVRepository
        {
            get
            {
                return this.lovRepository;
            }
        }

        public IExceptionHelper ExceptionHelper
        {
            get
            {
                return this.exceptionHelper;
            }
        }
        
        public IRoleRepository RoleRepository
        {
            get
            {
                return this.roleRepository;
            }
        }
        
        public IPermissionRepository PermissionRepository
        {
            get
            {
                return this.permissionRepository;
            }
        }
        
        public IPushNotificationRepository PushNotificationRepository
        {
            get
            {
                return this.pushNotificationRepository;
            }
        }
        
        public IRequestInfo RequestInfo
        {
            get
            {
                return this.requestInfo;
            }
        }

        public IDoctorRepository DoctorRepository
        {
            get
            {
                return this.doctorRepository;
            }
        }

        public IDoctorCategoryRepository DoctorCategoryRepository
        {
            get
            {
                return this.doctorCategoryRepository;
            }
        }

        public IDoctorOPDRepository DoctorOPDRepository
        {
            get
            {
                return this.doctorOPDRepository;
            }
        }

        public IDoctorOpdDateRepository DoctorOpdDateRepository
        {
            get
            {
                return this.doctorOpdDateRepository;
            }
        }

        public IOPDRepository OPDRepository
        {
            get
            {
                return this.opdRepository;
            }
        }

        public IConsultancyTimingRepository ConsultancyTimingRepository
        {
            get
            {
                return this.consultancyTimingRepository;
            }
        }

        public IAppointmentRepository AppointmentRepository
        {
            get
            {
                return this.appointmentRepository;
            }
        }

        public IBirthRepository BirthRepository
        {
            get
            {
                return this.birthRepository;
            }
        }

        public IDeathRepository DeathRepository
        {
            get
            {
                return this.deathRepository;
            }
        }

        public IBuildingMaterialCategoryRepository BuildingMaterialCategoryRepository
        {
            get
            {
                return this.buildingMaterialCategoryRepository;
            }
        }

        public IBuildingMaterialRepository BuildingMaterialRepository
        {
            get
            {
                return this.buildingMaterialRepository;
            }
        }

        public IWardCategoryRepository WardCategoryRepository
        {
            get
            {
                return this.wardCategoryRepository;
            }
        }

        public IRoomRepository RoomRepository
        {
            get
            {
                return this.roomRepository;
            }
        }

        public IBedRepository BedRepository
        {
            get
            {
                return this.bedRepository;
            }
        }

        public IBedAllocationRepository BedAllocationRepository
        {
            get
            {
                return this.bedAllocationRepository;
            }
        }

        public ILabDepartmentRepository LabDepartmentRepository
        {
            get
            {
                return this.labDepartmentRepository;
            }
        }

        public ILabDepartmentServicesRepository LabDepartmentServicesRepository
        {
            get
            {
                return this.labDepartmentServicesRepository;
            }
        }

        public IRateSheetRepository RateSheetRepository
        {
            get
            {
                return this.rateSheetRepository;
            }
        }
        
        public ILabTestingUnitRepository LabTestingUnitRepository
        {
            get
            {
                return this.labTestingUnitRepository;
            }
        }

        public ITestParameterRepository TestParameterRepository
        {
            get
            {
                return this.testParameterRepository;
            }
        }
        
        public ILabTestBuilderRepository LabTestBuilderRepository
        {
            get
            {
                return this.labTestBuilderRepository;
            }
        }

        public ILabTestByValueRepository LabTestByValueRepository
        {
            get
            {
                return this.labTestByValueRepository;
            }
        }

        public ILabTestByEditorRepository LabTestByEditorRepository
        {
            get
            {
                return this.labTestByEditorRepository;
            }
        }

        public ILabTestTemplateRepository LabTestTemplateRepository
        {
            get
            {
                return this.labTestTemplateRepository;
            }
        }

        public IOPDRegistrationRepository OPDRegistrationRepository
        {
            get
            {
                return this.opdRegistrationRepository;
            }
        }

        public ILabTestOrderRepository LabTestOrderRepository
        {
            get
            {
                return this.labTestOrderRepository;
            }
        }

        public ILabTestOrderDetailRepository LabTestOrderDetailRepository
        {
            get
            {
                return this.labTestOrderDetailRepository;
            }
        }

        public ICompanyAccountLevelRepository CompanyAccountLevelRepository
        {
            get
            {
                return this.companyAccountLevelRepository;
            }
        }

        public ICompanyAccountRepository CompanyAccountRepository
        {
            get
            {
                return this.companyAccountRepository;
            }
        }

        public IIncomeGroupRepository IncomeGroupRepository
        {
            get
            {
                return this.incomeGroupRepository;
            }
        }

        public ILabInvoiceRepository LabInvoiceRepository
        {
            get
            {
                return this.labInvoiceRepository;
            }
        }

        public ILabInvoiceDetailRepository LabInvoiceDetailRepository
        {
            get
            {
                return this.labInvoiceDetailRepository;
            }
        }

        public ILabSampleTypeRepository LabSampleTypeRepository
        {
            get
            {
                return this.labSampleTypeRepository;
            }
        }

        public ILabSampleRepository LabSampleRepository
        {
            get
            {
                return this.labSampleRepository;
            }
        }

        public ILabTestSampleRepository LabTestSampleRepository
        {
            get
            {
                return this.labTestSampleRepository;
            }
        }

        public IInventoryCategoryRepository InventoryCategoryRepository
        {
            get
            {
                return this.inventoryCategoryRepository;
            }
        }

        public IInventoryItemRepository InventoryItemRepository
        {
            get
            {
                return this.inventoryItemRepository;
            }
        }

        public ILabOutSourceRepository LabOutSourceRepository
        {
            get
            {
                return this.labOutSourceRepository;
            }
        }

        public IDoctorOPDTimeSlotRepository DoctorOPDTimeSlotRepository
        {
            get
            {
                return this.doctorOPDTimeSlotRepository;
            }
        }

        public ILabTestInventoryAllocationRepository LabTestInventoryAllocationRepository
        {
            get
            {
                return this.labTestInventoryAllocationRepository;
            }
        }

        public IProductCategoryRepository ProductCategoryRepository
        {
            get
            {
                return this.productCategoryRepository;
            }
        }

        public IProductChemicalRepository ProductChemicalRepository
        {
            get
            {
                return this.productChemicalRepository;
            }
        }

        public IProductMeasurementUnitRepository ProductMeasurementUnitRepository
        {
            get
            {
                return this.productMeasurementUnitRepository;
            }
        }

        public IProductTypeRepository ProductTypeRepository
        {
            get
            {
                return this.productTypeRepository;
            }
        }

        public IProductUnitRepository ProductUnitRepository
        {
            get
            {
                return this.productUnitRepository;
            }
        }

        public IBrandRepository BrandRepository
        {
            get
            {
                return this.brandRepository;
            }
        }

        public IRacksRepository RacksRepository
        {
            get
            {
                return this.racksRepository;
            }
        }

        public ICatastrophicEventRepository CatastrophicEventRepository
        {
            get
            {
                return this.catastrophicEventRepository;
            }
        }

        public IAccidentAndEmergencyRepository AccidentAndEmergencyRepository
        {
            get
            {
                return this.accidentAndEmergencyRepository;
            }
        }

        public IBroughterDetailsRepository BroughterDetailsRepository
        {
            get
            {
                return this.broughterDetailsRepository;
            }
        }

        public IAmbulanceDetailsRepository AmbulanceDetailsRepository
        {
            get
            {
                return this.ambulanceDetailsRepository;
            }
        }

        public IBuildingFloorRepository BuildingFloorRepository
        {
            get
            {
                return this.buildingFloorRepository;
            }
        }

        public IClientGroupRepository ClientGroupRepository
        {
            get
            {
                return this.clientGroupRepository;
            }
        }

        public IClientTypeRepository ClientTypeRepository
        {
            get
            {
                return this.clientTypeRepository;
            }
        }

        public ICPTCategoryRepository CPTCategoryRepository
        {
            get
            {
                return this.cptCategoryRepository;
            }
        }

        public IGroupOfCompaniesRepository GroupOfCompaniesRepository
        {
            get
            {
                return this.groupOfCompaniesRepository;
            }
        }

        public IOrganizationRepository OrganizationRepository
        {
            get
            {
                return this.organizationRepository;
            }
        }

        public IOrganizationalDivisionRepository OrganizationalDivisionRepository
        {
            get
            {
                return this.organizationalDivisionRepository;
            }
        }

        public IOrganizationalDivisionDepartmentRepository OrganizationalDivisionDepartmentRepository
        {
            get
            {
                return this.organizationalDivisionDepartmentRepository;
            }
        }

        public ILisenceRepository LisenceRepository
        {
            get
            {
                return this.lisenceRepository;
            }
        }


        public IAmbulanceRepository AmbulanceRepository
        {
            get
            {
                return this.ambulanceRepository;
            }
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await this.DBContext.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                this.exceptionHelper.ThrowAPIException(e.EntityValidationErrors.First().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return 0;
        }

        public int Save()
        {
            try
            {
                return this.DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public System.Data.Entity.DbContextTransaction BeginTransaction()
        {
            return this.DBContext.Database.BeginTransaction();
        }
    }
}
