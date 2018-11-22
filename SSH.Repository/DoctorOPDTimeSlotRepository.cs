using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Recipe.Common.Helper;
using Recipe.Core.Base.Generic;
using SSH.Common.Helper;
using SSH.Core.Constant;
using SSH.Core.DTO;
using SSH.Core.Entity;
using SSH.Core.Enum;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class DoctorOPDTimeSlotRepository : AuditableRepository<DoctorOPDTimeSlot, int>, IDoctorOPDTimeSlotRepository
    {
        private ISSHRequestInfo requestInfo;

        public DoctorOPDTimeSlotRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }

        protected override IQueryable<DoctorOPDTimeSlot> DefaultListQuery
        {
            get
            {
                return base.DefaultListQuery.Where(x => x.IsDeleted == false);
            }
        }

        protected override IQueryable<DoctorOPDTimeSlot> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery.Where(x => x.IsDeleted == false);
            }
        }

        public async Task<IEnumerable<DoctorOPDTimeSlot>> GetByStatus(DoctorOPDTimeSlotStatus status)
        {
            return await this.DefaultListQuery.Where(x => x.Status == (int)status).ToListAsync();
        }

        public async Task<DoctorOPDTimeSlot> GetRecordOfMaxDateByDoctorOpd(int doctoropd_id)
        {
            var entity = await this.DefaultListQuery.Where(x => x.DoctorOPDId == doctoropd_id).OrderByDescending(x => x.AppointmentDate).FirstOrDefaultAsync();

            return entity;
        }

        // Check is patient exist on that slot. So that should not given to other patient.
        public async Task<DoctorOPDTimeSlot> IsPatientOnThatSlotExist(int doctoropd_id, DateTime date, int slotNo)
        {
            var entity = await this.DefaultSingleQuery.Where(x => x.DoctorOPDId == doctoropd_id && 
            x.AppointmentDate == date && x.SlotNumber == slotNo && x.Status != (int)DoctorOPDTimeSlotStatus.Cancel).FirstOrDefaultAsync();

            return entity;
        }

        // GET ALL APPOINTMENTS TIME SLOTS BY DOCTOR OPD ID & Provided Date
        public async Task<IList<DoctorOPDTimeSlot>> GetAppointmentTimeSlotsByDoctorOpd(int doctorOpdId, DateTime appointmentDate)
        {
            var entity = await this.DefaultListQuery.Where(x => x.DoctorOPDId == doctorOpdId && x.AppointmentDate == appointmentDate).ToListAsync();

            return entity;
        }
    }
}
