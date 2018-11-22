using System;
using System.Collections.Generic;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class LabSampleTypeDTO : DTO<LabSampleType, int>
    {
        public string SampleName { get; set; }

        public string SampleType { get; set; }

        public string Colour { get; set; }

        public string ContainerType { get; set; }

        public string CollectionInstruction { get; set; }

        public string ContainerColour { get; set; }

        public string Prefix { get; set; }

        public bool IsPrefix { get; set; }

        public string Description { get; set; }

        public override void ConvertFromEntity(LabSampleType entity)
        {
            base.ConvertFromEntity(entity);
            this.SampleName = entity.SampleName;
            this.SampleType = entity.SampleType;
            this.Colour = entity.Colour;
            this.ContainerType = entity.ContainerType;
            this.CollectionInstruction = entity.CollectionInstruction;
            this.ContainerColour = entity.ContainerColour;
            this.Prefix = entity.Prefix;
            this.IsPrefix = entity.IsPrefix;
            this.Description = entity.Description;
        }

        public override LabSampleType ConvertToEntity(LabSampleType entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.SampleName = this.SampleName;
            entity.SampleType = this.SampleType;
            entity.Colour = this.Colour;
            entity.ContainerType = this.ContainerType;
            entity.CollectionInstruction = this.CollectionInstruction;
            entity.ContainerColour = this.ContainerColour;
            entity.Prefix = this.Prefix;
            entity.IsPrefix = this.IsPrefix;
            entity.Description = this.Description;

            return entity;
        }
    }
}