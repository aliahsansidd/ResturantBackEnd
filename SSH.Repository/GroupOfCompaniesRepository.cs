using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class GroupOfCompaniesRepository : AuditableRepository<GroupOfCompanies, int>, IGroupOfCompaniesRepository
    {
        private ISSHRequestInfo requestInfo;

        public GroupOfCompaniesRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
