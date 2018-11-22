using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class DoctorOpdDateRepository : AuditableRepository<DoctorOpdDate, int>, IDoctorOpdDateRepository
    {
        private ISSHRequestInfo requestInfo;

        public DoctorOpdDateRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
