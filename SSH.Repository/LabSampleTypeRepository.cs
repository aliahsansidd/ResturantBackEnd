using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class LabSampleTypeRepository : AuditableRepository<LabSampleType, int>, ILabSampleTypeRepository
    {
        private ISSHRequestInfo requestInfo;

        public LabSampleTypeRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
