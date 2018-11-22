using System.Collections.Generic;
using System.Threading.Tasks;
using Recipe.Core.Base.Interface;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.IRepository
{
    public interface IAppointmentRepository : IRepository<Appointment, int>
    {
        Task<IEnumerable<Appointment>> GetByStatus(AppointmentStatus status);
    }
}
