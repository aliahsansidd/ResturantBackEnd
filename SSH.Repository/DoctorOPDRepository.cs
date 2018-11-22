using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class DoctorOPDRepository : AuditableRepository<DoctorOPD, int>, IDoctorOPDRepository
    {
        private readonly ISSHRequestInfo requestInfo;

        public DoctorOPDRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }

        protected override IQueryable<DoctorOPD> DefaultListQuery
        {
            get
            {
                return base.DefaultListQuery.Where(x => x.IsDeleted == false)
                    .Include(x => x.DoctorOpdDate).Where(x => x.IsDeleted == false)
                    .Include(x => x.Doctor)
                    .Include(x => x.Doctor.ApplicationUserDoctor)
                    .Include(x => x.DoctorCategory)
                    .Include(x => x.OPD)
                    .Include(x => x.Room);
            }
        }

        protected override IQueryable<DoctorOPD> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery.Where(x => x.IsDeleted == false)
                    .Include(x => x.DoctorOpdDate).Where(x => x.IsDeleted == false)
                    .Include(x => x.Doctor)
                    .Include(x => x.Doctor.ApplicationUserDoctor)
                    .Include(x => x.DoctorCategory)
                    .Include(x => x.OPD)
                    .Include(x => x.Room);
            }
        }

        //public async Task<DoctorOPD> Get()
        //{
        //    return await this.DefaultListQuery.OrderByDescending(x => x.OperationTime).Take(500).ToListAsync();
        //}
    }
}
