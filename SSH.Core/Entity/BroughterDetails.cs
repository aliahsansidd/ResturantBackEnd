using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class BroughterDetails : EntityBase<int>
    {
        public BroughterDetails()
        {    
        }

        public string Name { get; set; }

        public string CNIC { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public int? ModeOfArrival { get; set; }

        public int? AccidentAndEmergencyID { get; set; }

        public virtual AccidentAndEmergency AccidentAndEmergency { get; set; }
    }
}
