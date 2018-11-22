using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class WardCategoryRepository : AuditableRepository<WardCategory, int>, IWardCategoryRepository
    {
        private ISSHRequestInfo requestInfo;

        public WardCategoryRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
