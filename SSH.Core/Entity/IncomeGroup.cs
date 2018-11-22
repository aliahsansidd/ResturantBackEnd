using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class IncomeGroup : EntityBase<int>
    {
        public IncomeGroup()
        {    
        }

        public string Description { get; set; }

        public int Status { get; set; }

        public virtual IList<LabInvoice> LabInvoice { get; set; }
    }
}
