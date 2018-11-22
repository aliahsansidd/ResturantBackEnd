using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class LabTestInventoryAllocation : EntityBase<int>
    {
        public LabTestInventoryAllocation()
        {    
        }

        public int Quantity { get; set; }

        public int LabTestBuilderId { get; set; }

        public virtual LabTestBuilder LabTestBuilder { get; set; }
    }
}
