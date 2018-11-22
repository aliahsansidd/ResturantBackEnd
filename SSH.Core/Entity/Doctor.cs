using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class Doctor : EntityBase<int>
    {
        public Doctor()
        {    
        }

        public string ApplicationUserDoctorId { get; set; }

        public virtual ApplicationUser ApplicationUserDoctor { get; set; }

        public int DoctorCategoryId { get; set; }

        public virtual DoctorCategory DoctorCategory { get; set; }

        public string Contact1 { get; set; }

        public string Contact2 { get; set; }

        public int Status { get; set; }

        public virtual IList<DoctorOPD> DoctorOPD { get; set; }

        public virtual IList<Appointment> Appointment { get; set; }

        public virtual IList<Birth> Birth { get; set; }
    }
}
