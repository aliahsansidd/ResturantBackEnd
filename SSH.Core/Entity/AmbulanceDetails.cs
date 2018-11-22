using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class AmbulanceDetails : EntityBase<int>
    {
        public AmbulanceDetails()
        {    
        }

        public string Name { get; set; }

        public string VehicleNo { get; set; }

        public string CenterNo { get; set; }

        public string Location { get; set; }

        public string MadadgarName { get; set; }

        public int? AccidentAndEmergencyID { get; set; }

        public virtual AccidentAndEmergency AccidentAndEmergency { get; set; }
    }
}
