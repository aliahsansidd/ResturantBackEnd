using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class OrganizationalDivisionRepository : AuditableRepository<OrganizationalDivision, int>, IOrganizationalDivisionRepository
    {
        private ISSHRequestInfo requestInfo;

        public OrganizationalDivisionRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
