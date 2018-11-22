using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class AmbulanceDetailsRepository : AuditableRepository<AmbulanceDetails, int>, IAmbulanceDetailsRepository
    {
        private ISSHRequestInfo requestInfo;

        public AmbulanceDetailsRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
