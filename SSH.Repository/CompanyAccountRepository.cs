using System.Data.Entity;
using System.Linq;
using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class CompanyAccountRepository : AuditableRepository<CompanyAccount, int>, ICompanyAccountRepository
    {
        private ISSHRequestInfo requestInfo;

        public CompanyAccountRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
