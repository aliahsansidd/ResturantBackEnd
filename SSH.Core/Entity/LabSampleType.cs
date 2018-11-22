using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class LabSampleType : EntityBase<int>
    {
        public LabSampleType()
        {    
        }

        public string SampleName { get; set; }

        public string SampleType { get; set; }

        public string Colour { get; set; }

        public string ContainerType { get; set; }

        public string CollectionInstruction { get; set; }

        public string ContainerColour { get; set; }

        [MaxLength(2)]
        public string Prefix { get; set; }

        public bool IsPrefix { get; set; }

        public string Description { get; set; }
    }
}
