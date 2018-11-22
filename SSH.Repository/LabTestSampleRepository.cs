using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class LabTestSampleRepository : AuditableRepository<LabTestSample, int>, ILabTestSampleRepository
    {
        private ISSHRequestInfo requestInfo;

        public LabTestSampleRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
