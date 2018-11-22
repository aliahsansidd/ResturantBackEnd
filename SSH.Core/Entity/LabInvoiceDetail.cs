using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class LabInvoiceDetail : EntityBase<int>
    {
        public LabInvoiceDetail()
        {    
        }

        public int LabInvoiceId { get; set; }

        public virtual LabInvoice LabInvoice { get; set; }

        public int LabTestBuilderId { get; set; }

        public virtual LabTestBuilder LabTestBuilder { get; set; }

        public double TestUnitPrice { get; set; }
    }
}
