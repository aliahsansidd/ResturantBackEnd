using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class Ambulance : EntityBase<int>
    {
        public Ambulance()
        {
        }
        
        public string BrandName { get; set; }

        public string Category { get; set; }

        public string Version { get; set; }

        public string CenterName { get; set; }

        public string Location { get; set; }

        public string ChassisNo { get; set; }

        public string EngineNo { get; set; }

        public int Status { get; set; }
        
    }
}
