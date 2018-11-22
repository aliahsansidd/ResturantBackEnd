using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class DoctorOPDTimeSlotDTO : DTO<DoctorOPDTimeSlot, int>
    {
        public int DoctorOPDId { get; set; }

        public int SlotNumber { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public DateTime AppointmentDate { get; set; }

        public int AppointmentId { get; set; }

        public int? PatientId { get; set; }

        // None, Pending, Cancel, Complete
        public DoctorOPDTimeSlotStatus Status { get; set; }

        public string CreatedOn { get; set; }

        public override void ConvertFromEntity(DoctorOPDTimeSlot entity)
        {
            base.ConvertFromEntity(entity);
            this.AppointmentId = entity.AppointmentId;
            this.DoctorOPDId = entity.DoctorOPDId;
            this.PatientId = (entity.PatientId == null) ? 0 : entity.PatientId;
            this.StartTime = entity.StartTime;
            this.EndTime = entity.EndTime;
            this.AppointmentDate = entity.AppointmentDate;
            this.SlotNumber = entity.SlotNumber;
            this.Status = (DoctorOPDTimeSlotStatus)entity.Status;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
        }

        public override DoctorOPDTimeSlot ConvertToEntity(DoctorOPDTimeSlot entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.AppointmentId = this.AppointmentId;
            entity.DoctorOPDId = this.DoctorOPDId;
            entity.PatientId = (this.PatientId == 0 || this.PatientId == null) ? null : this.PatientId;
            entity.StartTime = this.StartTime;
            entity.EndTime = this.EndTime;
            entity.AppointmentDate = this.AppointmentDate.Date;
            entity.SlotNumber = this.SlotNumber;
            entity.Status = (int)this.Status;
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastModifiedOn = DateTime.UtcNow;

            return entity;
        }
    }
}
