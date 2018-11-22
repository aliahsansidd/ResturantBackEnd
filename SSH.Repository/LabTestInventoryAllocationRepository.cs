using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class LabTestInventoryAllocationRepository : AuditableRepository<LabTestInventoryAllocation, int>, ILabTestInventoryAllocationRepository
    {
        private ISSHRequestInfo requestInfo;

        public LabTestInventoryAllocationRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
