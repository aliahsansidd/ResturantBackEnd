using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class AmbulanceRepository : AuditableRepository<Ambulance, int>, IAmbulanceRepository
    {
        private ISSHRequestInfo requestInfo;

        public AmbulanceRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
