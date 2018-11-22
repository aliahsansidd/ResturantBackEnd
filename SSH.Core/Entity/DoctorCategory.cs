using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class DoctorCategory : EntityBase<int>
    {
        public DoctorCategory()
        {    
        }

        public string Name { get; set; }

        public double Fee { get; set; }

        public int Status { get; set; }

        public virtual IList<Doctor> Doctor { get; set; }
    }
}
