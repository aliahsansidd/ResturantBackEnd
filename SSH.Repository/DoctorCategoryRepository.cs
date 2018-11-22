using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class DoctorCategoryRepository : AuditableRepository<DoctorCategory, int>, IDoctorCategoryRepository
    {
        private ISSHRequestInfo requestInfo;

        public DoctorCategoryRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
