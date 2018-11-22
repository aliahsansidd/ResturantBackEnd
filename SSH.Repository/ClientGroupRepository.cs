using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class ClientGroupRepository : AuditableRepository<ClientGroup, int>, IClientGroupRepository
    {
        private ISSHRequestInfo requestInfo;

        public ClientGroupRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
