using System.Data.Entity;
using System.Linq;
using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class LabTestOrderDetailRepository : AuditableRepository<LabTestOrderDetail, int>, ILabTestOrderDetailRepository
    {
        private ISSHRequestInfo requestInfo;

        public LabTestOrderDetailRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
