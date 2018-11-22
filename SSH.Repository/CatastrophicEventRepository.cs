using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class CatastrophicEventRepository : AuditableRepository<CatastrophicEvent, int>, ICatastrophicEventRepository
    {
        private ISSHRequestInfo requestInfo;

        public CatastrophicEventRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
