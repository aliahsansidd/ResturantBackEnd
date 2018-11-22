using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class LabInvoice : EntityBase<int>
    {
        public LabInvoice()
        {    
        }

        public int LabTestOrderId { get; set; }

        public virtual LabTestOrder LabTestOrder { get; set; }

        public int IncomeGroupId { get; set; }

        public virtual IncomeGroup IncomeGroup { get; set; }

        public double TotalAmount { get; set; }

        public double ReceivedAmount { get; set; }

        public double DueAmount { get; set; }

        public double Tax { get; set; }

        public bool IsBillPaid { get; set; }

        public virtual IList<LabInvoiceDetail> LabInvoiceDetail { get; set; }
    }
}
