using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class CPTCategoryRepository : AuditableRepository<CPTCategory, int>, ICPTCategoryRepository
    {
        private ISSHRequestInfo requestInfo;

        public CPTCategoryRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
