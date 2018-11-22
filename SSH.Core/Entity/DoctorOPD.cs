using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class DoctorOPD : EntityBase<int>
    {
        public DoctorOPD()
        {
        }

        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        public int OPDId { get; set; }

        public virtual OPD OPD { get; set; }

        public int DoctorCategoryId { get; set; }

        public virtual DoctorCategory DoctorCategory { get; set; }

        [Required]
        public int DurationInMinutes { get; set; }

        [Required]
        public int NoOfTimeSlots { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        public double Fee { get; set; }

        public int DrAvailability { get; set; }

        public string DrAvailabilityReason { get; set; }

        [Required]
        public bool IsRoutineBased { get; set; }

        public string WeekAndDays { get; set; }

        public DateTime? StartDateRange { get; set; }

        public DateTime? EndDateRange { get; set; }

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }

        public virtual IList<DoctorOpdDate> DoctorOpdDate { get; set; }
    }
}
