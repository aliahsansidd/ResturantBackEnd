using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class Patient : EntityBase<int>
    {
        public Patient()
        {    
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FamilyHeadName { get; set; }

        public string CellNumber { get; set; }

        public string LandLineNumber { get; set; }

        public string EmergencyNumber { get; set; }

        public string Address { get; set; }

        public string CNIC { get; set; }

        public string City { get; set; }

        public DateTime? DOB { get; set; }

        public int? Age { get; set; }

        public string Gender { get; set; }

        public string Religion { get; set; }

        public string MaritalStatus { get; set; }

        public int Status { get; set; }

        public DateTime CardExpiry { get; set; }

        public virtual IList<Birth> Birth { get; set; }

        public virtual IList<Death> Death { get; set; }

        public virtual IList<BedAllocation> BedAllocation { get; set; }
    }
}
