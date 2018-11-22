using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class LabOutSource : EntityBase<int>
    {
        public LabOutSource()
        {    
        }

        public string Name { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public virtual IList<LabTestBuilder> LabTestBuilder { get; set; }
    }
}
