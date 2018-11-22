using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Recipe.Common.Helper;
using Recipe.Core.Base.Generic;
using SSH.Common.Helper;
using SSH.Core.Constant;
using SSH.Core.DTO;
using SSH.Core.Entity;
using SSH.Core.Enum;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class OPDRegistrationRepository : AuditableRepository<OPDRegistration, int>, IOPDRegistrationRepository
    {
        private ISSHRequestInfo requestInfo;

        public OPDRegistrationRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }

        protected override IQueryable<OPDRegistration> DefaultListQuery
        {
            get
            {
                return base.DefaultListQuery
                    .Include(x => x.Patient);
            }
        }

        protected override IQueryable<OPDRegistration> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery
                    .Include(x => x.Patient);
            }
        }

        public async Task<IEnumerable<OPDRegistration>> GetByStatus(DoctorOPDTimeSlotStatus status)
        {
            return await this.DefaultListQuery.Where(x => x.Status == (int)status).ToListAsync();
        }
    }
}
