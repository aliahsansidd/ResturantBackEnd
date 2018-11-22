using System.Data.Entity;
using System.Threading.Tasks;
using Recipe.Core.Base.Interface;
using SSH.Core.Infrastructure;

namespace SSH.Core.IRepository
{
    public interface ISSHUnitOfWork : IUnitOfWork
    {
        IRequestInfo RequestInfo { get; }

        IUserRepository UserRepository { get; }
        
        IAuditRepository AuditRepository { get; }
        
        IEmailNotificationRepository EmailNotificationRepository { get; }

        IOTPRepository OTPRepository { get; }

        ILOVRepository LOVRepository { get; }

        IExceptionHelper ExceptionHelper { get; }

        IUserRolePermissionRepository UserRolePermissionRepository { get; }
        
        IRoleRepository RoleRepository { get; }
        
        IPermissionRepository PermissionRepository { get; }
        
        IPushNotificationRepository PushNotificationRepository { get; }

        IUserSessionRepository UserSessionRepository { get; }

        IPatientRepository PatientRepository { get; }

        IDoctorRepository DoctorRepository { get; }

        IDoctorCategoryRepository DoctorCategoryRepository { get; }

        IDoctorOPDRepository DoctorOPDRepository { get; }

        IDoctorOpdDateRepository DoctorOpdDateRepository { get; }

        IOPDRepository OPDRepository { get; }

        IConsultancyTimingRepository ConsultancyTimingRepository { get; }

        IAppointmentRepository AppointmentRepository { get; }

        IBirthRepository BirthRepository { get; }

        IDeathRepository DeathRepository { get; }

        IBuildingMaterialCategoryRepository BuildingMaterialCategoryRepository { get; }

        IBuildingMaterialRepository BuildingMaterialRepository { get; }

        IWardCategoryRepository WardCategoryRepository { get; }

        IRoomRepository RoomRepository { get; }

        IBedRepository BedRepository { get; }

        IBedAllocationRepository BedAllocationRepository { get; }

        ILabDepartmentRepository LabDepartmentRepository { get; }

        ILabDepartmentServicesRepository LabDepartmentServicesRepository { get; }

        IRateSheetRepository RateSheetRepository { get; }

        ILabTestingUnitRepository LabTestingUnitRepository { get; }

        ITestParameterRepository TestParameterRepository { get; }

        ILabTestBuilderRepository LabTestBuilderRepository { get; }

        ILabTestByValueRepository LabTestByValueRepository { get; }

        ILabTestByEditorRepository LabTestByEditorRepository { get; }

        ILabTestTemplateRepository LabTestTemplateRepository { get; }

        IOPDRegistrationRepository OPDRegistrationRepository { get; }

        ILabTestOrderRepository LabTestOrderRepository { get; }

        ILabTestOrderDetailRepository LabTestOrderDetailRepository { get; }

        ICompanyAccountLevelRepository CompanyAccountLevelRepository { get; }

        ICompanyAccountRepository CompanyAccountRepository { get; }

        IIncomeGroupRepository IncomeGroupRepository { get; }

        ILabInvoiceRepository LabInvoiceRepository { get; }

        ILabInvoiceDetailRepository LabInvoiceDetailRepository { get; }

        ILabSampleTypeRepository LabSampleTypeRepository { get; }

        ILabSampleRepository LabSampleRepository { get; }

        IInventoryCategoryRepository InventoryCategoryRepository { get; }

        IInventoryItemRepository InventoryItemRepository { get; }

        ILabOutSourceRepository LabOutSourceRepository { get; }

        IDoctorOPDTimeSlotRepository DoctorOPDTimeSlotRepository { get; }

        ILabTestInventoryAllocationRepository LabTestInventoryAllocationRepository { get; }

        ILabTestSampleRepository LabTestSampleRepository { get; }

        IProductCategoryRepository ProductCategoryRepository { get; }

        IProductChemicalRepository ProductChemicalRepository { get; }

        IProductMeasurementUnitRepository ProductMeasurementUnitRepository { get; }

        IProductTypeRepository ProductTypeRepository { get; }

        IProductUnitRepository ProductUnitRepository { get; }

        IBrandRepository BrandRepository { get; }

        IRacksRepository RacksRepository { get; }

        ICatastrophicEventRepository CatastrophicEventRepository { get; }

        IAccidentAndEmergencyRepository AccidentAndEmergencyRepository { get; }

        IAmbulanceDetailsRepository AmbulanceDetailsRepository { get; }

        IBroughterDetailsRepository BroughterDetailsRepository { get; }

        IBuildingFloorRepository BuildingFloorRepository { get; }

        IClientGroupRepository ClientGroupRepository { get; }

        IClientTypeRepository ClientTypeRepository { get; }

        ICPTCategoryRepository CPTCategoryRepository { get; }

        IGroupOfCompaniesRepository GroupOfCompaniesRepository { get; }

        IOrganizationRepository OrganizationRepository { get; }

        ILisenceRepository LisenceRepository { get; }

        IOrganizationalDivisionRepository OrganizationalDivisionRepository { get; }

        IOrganizationalDivisionDepartmentRepository OrganizationalDivisionDepartmentRepository { get; }

        IAmbulanceRepository AmbulanceRepository { get; }

        Task<int> SaveAsync();

        int Save();

        DbContextTransaction BeginTransaction();
    }
}