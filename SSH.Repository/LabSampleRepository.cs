using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class LabSampleRepository : AuditableRepository<LabSample, int>, ILabSampleRepository
    {
        private ISSHRequestInfo requestInfo;

        public LabSampleRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
