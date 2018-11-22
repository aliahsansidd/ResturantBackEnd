using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class DoctorRepository : AuditableRepository<Doctor, int>, IDoctorRepository
    {
        private ISSHRequestInfo requestInfo;

        public DoctorRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
