using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class InsuranceCompaniesRepository : AuditableRepository<InsuranceCompanies, int>, IInsuranceCompaniesRepository
    {
        private ISSHRequestInfo requestInfo;

        public InsuranceCompaniesRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
