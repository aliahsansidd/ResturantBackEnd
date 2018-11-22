using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class LabTestBuilder : EntityBase<int>
    {
        public LabTestBuilder()
        {    
        }

        public string Name { get; set; }

        public string Code { get; set; }

        public string DependencyTests { get; set; }

        public string Remarks { get; set; }

        public double Price { get; set; }

        public bool IsSampleNeeded { get; set; }

        public bool IsResultEntry { get; set; }

        // If Sample needed then obviously conduction is required
        public bool IsConductionRequired { get; set; }

        public TimeSpan ConductingDuration { get; set; }

        public int Status { get; set; }

        public int LabDepartmentServicesId { get; set; }

        public virtual LabDepartmentServices LabDepartmentServices { get; set; }

        public int? LabTestTemplateId { get; set; }

        public virtual LabTestTemplate LabTestTemplate { get; set; }

        // Lab Out Source
        public int? LabOutSourceId { get; set; }

        public virtual LabOutSource LabOutSource { get; set; }

        // Detail Relations By Master
        public virtual IList<LabTestOrderDetail> LabTestOrderDetail { get; set; }

        public virtual IList<LabTestSample> LabTestSample { get; set; }
    }
}