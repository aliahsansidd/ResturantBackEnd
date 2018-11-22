using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class RateSheetRepository : AuditableRepository<RateSheet, int>, IRateSheetRepository
    {
        private ISSHRequestInfo requestInfo;

        public RateSheetRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
