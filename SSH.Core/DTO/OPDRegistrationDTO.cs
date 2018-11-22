using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class OPDRegistrationDTO : DTO<OPDRegistration, int>
    {
        public string DisplayId { get; set; }

        public int PatientId { get; set; }

        public PatientDTO PatientDto { get; set; }

        public int? AppointmentId { get; set; }

        public AppointmentDTO AppointmentDto { get; set; }

        public int? DoctorId { get; set; }

        public string DoctorName { get; set; }

        public DoctorOPDTimeSlotStatus Status { get; set; }

        public string CreatedOn { get; set; }

        public override void ConvertFromEntity(OPDRegistration entity)
        {
            base.ConvertFromEntity(entity);
            this.PatientId = entity.PatientId;
            this.Status = (DoctorOPDTimeSlotStatus)entity.Status;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);

            if (entity.Patient != null)
            {
                PatientDTO patient = new PatientDTO();
                patient.ConvertFromEntity(entity.Patient);
                this.PatientDto = patient;
            }

            this.DisplayId = string.Format("{0}-{1}-{2}", "opd", entity.Id.ToString(), entity.CreatedOn.ToString("yy"));
        }

        public override OPDRegistration ConvertToEntity(OPDRegistration entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.PatientId = this.PatientId;
            entity.Status = (int)this.Status;

            return entity;
        }
    }
}