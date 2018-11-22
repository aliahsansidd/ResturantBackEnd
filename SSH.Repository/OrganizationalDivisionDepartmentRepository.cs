using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class OrganizationalDivisionDepartmentRepository : AuditableRepository<OrganizationalDivisionDepartment, int>, IOrganizationalDivisionDepartmentRepository
    {
        private ISSHRequestInfo requestInfo;

        public OrganizationalDivisionDepartmentRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
