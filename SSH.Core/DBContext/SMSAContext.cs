using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using SSH.Core.Entity;

namespace SSH.Core.DBContext
{
    public class SSHContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserLogin, ApplicationUserRole, IdentityUserClaim>
    {
        public SSHContext() : base("DefaultConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Audit> Audit { get; set; }

        public DbSet<AuditDetail> AuditDetail { get; set; }
        
        public DbSet<EmailNotification> EmailNotification { get; set; }
        
        public DbSet<LOV> LOV { get; set; }
        
        public DbSet<Permission> Permission { get; set; }

        public DbSet<UserRolePermission> UserRolePermission { get; set; }

        public DbSet<UserSession> UserSession { get; set; }

        public DbSet<OTP> OTP { get; set; }

        public DbSet<Patient> Patient { get; set; }

        public DbSet<ConsultancyTiming> ConsultancyTiming { get; set; }

        public DbSet<DoctorCategory> DoctorCategory { get; set; }

        public DbSet<OPD> OPD { get; set; }

        public DbSet<Doctor> Doctor { get; set; }

        public DbSet<DoctorOPD> DoctorOPD { get; set; }

        public DbSet<DoctorOpdDate> DoctorOpdDates { get; set; }

        public DbSet<Appointment> Appointment { get; set; }

        public DbSet<Birth> Birth { get; set; }

        public DbSet<Death> Death { get; set; }

        public DbSet<BuildingMaterialCategory> BuildingMaterialCategory { get; set; }

        public DbSet<BuildingMaterial> BuildingMaterial { get; set; }

        public DbSet<WardCategory> WardCategory { get; set; }

        public DbSet<Room> Room { get; set; }

        public DbSet<Bed> Bed { get; set; }

        public DbSet<BedAllocation> BedAllocation { get; set; }

        public DbSet<LabDepartment> LabDepartment { get; set; }

        public DbSet<LabDepartmentServices> LabDepartmentServices { get; set; }

        public DbSet<RateSheet> RateSheet { get; set; }

        public DbSet<LabTestingUnit> LabTestingUnit { get; set; }

        public DbSet<TestParameter> TestParameter { get; set; }

        public DbSet<LabTestBuilder> LabTestBuilder { get; set; }

        public DbSet<LabTestByValue> LabTestByValue { get; set; }

        public DbSet<LabTestByEditor> LabTestByEditor { get; set; }

        public DbSet<LabTestTemplate> LabTestTemplate { get; set; }

        public DbSet<OPDRegistration> OPDRegistration { get; set; }

        public DbSet<LabTestOrder> LabTestOrder { get; set; }

        public DbSet<LabTestOrderDetail> LabTestOrderDetail { get; set; }

        public DbSet<CompanyAccountLevel> CompanyAccountLevel { get; set; }

        public DbSet<CompanyAccount> CompanyAccount { get; set; }

        public DbSet<IncomeGroup> IncomeGroup { get; set; }

        public DbSet<LabInvoice> LabInvoice { get; set; }

        public DbSet<LabInvoiceDetail> LabInvoiceDetail { get; set; }

        public DbSet<LabSampleType> LabSampleType { get; set; }

        public DbSet<LabSample> LabSample { get; set; }

        public DbSet<LabTestSample> LabTestSample { get; set; }

        public DbSet<DoctorOPDTimeSlot> DoctorOPDTimeSlot { get; set; }

        public DbSet<LabTestInventoryAllocation> LabTestInventoryAllocation { get; set; }

        public DbSet<ProductCategory> ProductCategory { get; set; }

        public DbSet<ProductType> ProductType { get; set; }

        public DbSet<ProductUnit> ProductUnit { get; set; }

        public DbSet<ProductMeasurementUnit> ProductMeasurementUnit { get; set; }

        public DbSet<ProductChemical> ProductChemical { get; set; }

        public DbSet<Brand> Brand { get; set; }

        public DbSet<Racks> Racks { get; set; }

        public DbSet<CatastrophicEvent> CatastrophicEvent { get; set; }

        public DbSet<AccidentAndEmergency> AccidentAndEmergency { get; set; }

        public DbSet<BroughterDetails> BroughterDetails { get; set; }

        public DbSet<AmbulanceDetails> AmbulanceDetails { get; set; }

        public DbSet<BuildingFloor> BuildingFloor { get; set; }

        public DbSet<ClientGroup> ClientGroup { get; set; }

        public DbSet<ClientType> ClientType { get; set; }

        public DbSet<CPTCategory> CPTCategory { get; set; }

        public DbSet<GroupOfCompanies> GroupOfCompanies { get; set; }

        public DbSet<Organization> Organization { get; set; }

        public DbSet<Lisence> Lisence { get; set; }

        public DbSet<OrganizationalDivision> OrganizationalDivision { get; set; }

        public DbSet<Ambulance> Ambulance { get; set; }

        public DbSet<Driver> Driver { get; set; }

        public DbSet<OrganizationalDivisionDepartment> OrganizationalDivisionDepartment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
