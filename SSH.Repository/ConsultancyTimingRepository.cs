using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class ConsultancyTimingRepository : AuditableRepository<ConsultancyTiming, int>, IConsultancyTimingRepository
    {
        private ISSHRequestInfo requestInfo;

        public ConsultancyTimingRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
