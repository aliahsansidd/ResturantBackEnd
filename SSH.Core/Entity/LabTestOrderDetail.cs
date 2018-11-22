using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class LabTestOrderDetail : EntityBase<int>
    {
        public LabTestOrderDetail()
        {    
        }

        public int LabTestOrderId { get; set; }

        public virtual LabTestOrder LabTestOrder { get; set; }

        public int LabTestBuilderId { get; set; }

        public virtual LabTestBuilder LabTestBuilder { get; set; }

        public double TestUnitPrice { get; set; }

        public DateTime? EndTime { get; set; }

        public string DoctorRemarks { get; set; }

        public string TestReportUrl { get; set; }

        public bool IsUrgent { get; set; }

        public bool IsOutSource { get; set; }
        
        public string OutSourceHospitalName { get; set; }

        public int? DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        public int TestStatus { get; set; }

        public int Priority { get; set; }
    }
}
