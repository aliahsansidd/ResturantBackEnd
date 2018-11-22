using System.Data.Entity;
using System.Linq;
using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class AccidentAndEmergencyRepository : AuditableRepository<AccidentAndEmergency, int>, IAccidentAndEmergencyRepository
    {
        private ISSHRequestInfo requestInfo;

        public AccidentAndEmergencyRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }

        protected override IQueryable<AccidentAndEmergency> DefaultListQuery
        {
            get
            {
                return base.DefaultListQuery
                    .Include(x => x.BroughterDetails)
                    .Include(x => x.AmbulanceDetails);
            }
        }

        protected override IQueryable<AccidentAndEmergency> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery
                    .Include(x => x.BroughterDetails)
                    .Include(x => x.AmbulanceDetails);
            }
        }
    }
}
