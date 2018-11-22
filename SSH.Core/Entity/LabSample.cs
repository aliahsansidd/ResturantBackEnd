using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class LabSample : EntityBase<int>
    {
        public LabSample()
        {    
        }

        public int LabSampleTypeId { get; set; }

        public LabSampleType LabSampleType { get; set; }

        public int LabTestBuilderId { get; set; }

        public LabTestBuilder LabTestBuilder { get; set; }

        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public bool IsPrefix { get; set; }

        public string PrefixOrPostfixName { get; set; }

        public int SampleStatus { get; set; }
    }
}
