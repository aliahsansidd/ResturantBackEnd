using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class LabTestingUnit : EntityBase<int>
    {
        public LabTestingUnit()
        {    
        }

        public string Name { get; set; }

        public string Code { get; set; }

        public virtual IList<LabTestByValue> LabTestByValue { get; set; }
    }
}
