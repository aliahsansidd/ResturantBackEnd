using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class BroughterDetailsRepository : AuditableRepository<BroughterDetails, int>, IBroughterDetailsRepository
    {
        private ISSHRequestInfo requestInfo;

        public BroughterDetailsRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
