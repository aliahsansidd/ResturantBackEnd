using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class DoctorOPDTimeSlot : EntityBase<int>
    {
        public int DoctorOPDId { get; set; }

        public virtual DoctorOPD DoctorOPD { get; set; }

        [Required]
        public int SlotNumber { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        public int AppointmentId { get; set; }

        public virtual Appointment Appointment { get; set; }

        public int? PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        public int Status { get; set; }

        //public string Weeks { get; set; }
    }
}
