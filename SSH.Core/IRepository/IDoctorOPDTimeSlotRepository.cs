using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Recipe.Core.Base.Interface;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.IRepository
{
    public interface IDoctorOPDTimeSlotRepository : IRepository<DoctorOPDTimeSlot, int>
    {
        Task<IEnumerable<DoctorOPDTimeSlot>> GetByStatus(DoctorOPDTimeSlotStatus status);

        Task<DoctorOPDTimeSlot> GetRecordOfMaxDateByDoctorOpd(int doctoropd_id);

        Task<DoctorOPDTimeSlot> IsPatientOnThatSlotExist(int doctoropd_id, DateTime date, int slotNo);

        Task<IList<DoctorOPDTimeSlot>> GetAppointmentTimeSlotsByDoctorOpd(int doctorOpdId, DateTime appointmentDate);
    }
}
