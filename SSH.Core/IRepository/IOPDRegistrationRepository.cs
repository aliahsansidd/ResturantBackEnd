using System.Collections.Generic;
using System.Threading.Tasks;
using Recipe.Core.Base.Interface;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.IRepository
{
    public interface IOPDRegistrationRepository : IRepository<OPDRegistration, int>
    {
        Task<IEnumerable<OPDRegistration>> GetByStatus(DoctorOPDTimeSlotStatus status);
    }
}
