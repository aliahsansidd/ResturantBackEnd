using System.Collections.Generic;
using System.Threading.Tasks;
using Recipe.Core.Attribute;
using Recipe.Core.Base.Interface;
using Recipe.Core.Enum;
using SSH.Core.DTO;
using SSH.Core.Entity;
using SSH.Core.Enum;
using SSH.Core.IRepository;

namespace SSH.Core.IService
{
    public interface IAppointmentService : IService<IAppointmentRepository, Appointment, AppointmentDTO, int>
    {
        Task<List<AppointmentDTO>> GetByStatus(AppointmentStatus status);

        Task<int> DeleteAppointmentAsync(int id);
    }
}
