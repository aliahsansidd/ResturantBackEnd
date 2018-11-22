using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class LabTestOrder : EntityBase<int>
    {
        public LabTestOrder()
        {    
        }

        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        // WalkIn/InPatient
        public string PatientType { get; set; }

        // Cash/Card
        public string PaymentMode { get; set; }

        // PayNow/ PayLater
        public string BillType { get; set; }

        public int? DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        public string OutSourceDoctorName { get; set; }

        public string OutSourceHospitalName { get; set; }

        public virtual IList<LabTestOrderDetail> LabTestOrderDetail { get; set; }

        public int? RateSheetId { get; set; }

        public virtual RateSheet RateSheet { get; set; }

        public virtual IList<LabInvoice> LabInvoice { get; set; }
    }
}
