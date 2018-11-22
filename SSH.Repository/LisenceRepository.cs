using System.Threading.Tasks;
using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class LisenceRepository : AuditableRepository<Lisence, int>, ILisenceRepository
    {
        private ISSHRequestInfo requestInfo;

        public LisenceRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
