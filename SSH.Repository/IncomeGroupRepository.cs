using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class IncomeGroupRepository : AuditableRepository<IncomeGroup, int>, IIncomeGroupRepository
    {
        private ISSHRequestInfo requestInfo;

        public IncomeGroupRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
