using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class ClientTypeRepository : AuditableRepository<ClientType, int>, IClientTypeRepository
    {
        private ISSHRequestInfo requestInfo;

        public ClientTypeRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
