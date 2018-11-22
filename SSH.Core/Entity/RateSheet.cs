using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class RateSheet : EntityBase<int>
    {
        public RateSheet()
        {    
        }

        public string Name { get; set; }

        public double Increment { get; set; }

        public double Discount { get; set; }

        public int Status { get; set; }

        public virtual IList<LabTestOrder> LabTestOrder { get; set; }
    }
}
