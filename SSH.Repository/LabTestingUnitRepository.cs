using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class LabTestingUnitRepository : AuditableRepository<LabTestingUnit, int>, ILabTestingUnitRepository
    {
        private ISSHRequestInfo requestInfo;

        public LabTestingUnitRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
