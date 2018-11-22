using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class LabTestSample : EntityBase<int>
    {
        public LabTestSample()
        {    
        }

        public int LabSampleTypeId { get; set; }

        public virtual LabSampleType LabSampleType { get; set; }

        public int LabTestBuilderId { get; set; }

        public virtual LabTestBuilder LabTestBuilder { get; set; }

        public string SampleInstructions { get; set; }

        public string ConductingInstructions { get; set; }
    }
}
