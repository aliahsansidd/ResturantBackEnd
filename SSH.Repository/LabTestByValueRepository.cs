using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class LabTestByValueRepository : AuditableRepository<LabTestByValue, int>, ILabTestByValueRepository
    {
        private ISSHRequestInfo requestInfo;

        public LabTestByValueRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
