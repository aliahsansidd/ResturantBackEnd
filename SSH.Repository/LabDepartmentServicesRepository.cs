using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class LabDepartmentServicesRepository : AuditableRepository<LabDepartmentServices, int>, ILabDepartmentServicesRepository
    {
        private ISSHRequestInfo requestInfo;

        public LabDepartmentServicesRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
