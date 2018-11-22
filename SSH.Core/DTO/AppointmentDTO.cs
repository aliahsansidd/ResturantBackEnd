using System;
using System.Collections.Generic;
using System.Linq;
using Recipe.Core.Base.Abstract;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class AppointmentDTO : DTO<Appointment, int>
    {
        public string DisplayId { get; set; }

        public string PatientName { get; set; }

        public string ContactNumber { get; set; }

        //  None, Pending, Cancel, Completed
        public AppointmentStatus Status { get; set; }

        public int DoctorOPDId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public List<DoctorOPDTimeSlotDTO> DoctorOPDTimeSlotDto { get; set; }

        public string CreatedOn { get; set; }

        public override void ConvertFromEntity(Appointment entity)
        {
            base.ConvertFromEntity(entity);
            this.PatientName = entity.PatientName;
            this.ContactNumber = entity.ContactNumber;
            this.Status = (AppointmentStatus)entity.Status;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
            this.DisplayId = string.Format("{0}-{1}-{2}", "app", entity.Id.ToString(), entity.CreatedOn.ToString("yy"));
            this.DoctorOPDTimeSlotDto = entity.DoctorOPDTimeSlot != null ?
                entity.DoctorOPDTimeSlot.Count() > 0 ? DoctorOPDTimeSlotDTO.ConvertEntityListToDTOList<DoctorOPDTimeSlotDTO>(entity.DoctorOPDTimeSlot) : null : null;
        }

        public override Appointment ConvertToEntity(Appointment entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.PatientName = this.PatientName;
            entity.ContactNumber = this.ContactNumber;
            entity.Status = (int)this.Status;
            entity.DoctorOPDTimeSlot = this.DoctorOPDTimeSlotDto != null ?
                this.DoctorOPDTimeSlotDto.Count() > 0 ? DoctorOPDTimeSlotDTO.ConvertDTOListToEntity(this.DoctorOPDTimeSlotDto) : null : null;

            return entity;
        }
    }
}
