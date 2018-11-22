using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class CompanyAccountLevelRepository : AuditableRepository<CompanyAccountLevel, int>, ICompanyAccountLevelRepository
    {
        private ISSHRequestInfo requestInfo;

        public CompanyAccountLevelRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
