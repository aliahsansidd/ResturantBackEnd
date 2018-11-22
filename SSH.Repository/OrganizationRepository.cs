using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class OrganizationRepository : AuditableRepository<Organization, int>, IOrganizationRepository
    {
        private ISSHRequestInfo requestInfo;

        public OrganizationRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
