using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class DoctorOpdDate : EntityBase<int>
    {
        public DoctorOpdDate()
        {
        }

        [Required]
        public int DoctorOPDId { get; set; }

        public virtual DoctorOPD DoctorOPD { get; set; }

        [Required]
        public int OPDId { get; set; }

        public virtual OPD OPD { get; set; }

        [Required]
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [DefaultValue("false")]
        public bool IsSittingOnThisDate { get; set; }
    }
}
