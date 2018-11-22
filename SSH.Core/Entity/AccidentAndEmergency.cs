using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class AccidentAndEmergency : EntityBase<int>
    {
        public AccidentAndEmergency()
        {    
        }

        public int? PatientID { get; set; }

        public string MlNo { get; set; }

        public int? BroughtDeath { get; set; }

        public string Guardian { get; set; }

        public string PatientName { get; set; }

        public string Gender { get; set; }

        public string Complaint { get; set; }

        public string Address { get; set; }

        public string CNIC { get; set; }

        public string Phone { get; set; }

        public int? CatastrophicID { get; set; }

        public int? Age { get; set; }

        public int Status { get; set; }

        public virtual CatastrophicEvent CatastrophicEvent { get; set; }

        public virtual IList<BroughterDetails> BroughterDetails { get; set; }

        public virtual IList<AmbulanceDetails> AmbulanceDetails { get; set; }
    }
}
