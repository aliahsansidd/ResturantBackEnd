using System;
using System.Collections.Generic;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class LabTestSampleDTO : DTO<LabTestSample, int>
    {
        public int LabSampleTypeId { get; set; }

        public int LabTestBuilderId { get; set; }

        public string SampleInstructions { get; set; }

        public string ConductingInstructions { get; set; }

        public override void ConvertFromEntity(LabTestSample entity)
        {
            base.ConvertFromEntity(entity);
            this.LabSampleTypeId = entity.LabSampleTypeId;
            this.LabTestBuilderId = entity.LabTestBuilderId;
            this.SampleInstructions = entity.SampleInstructions;
            this.ConductingInstructions = entity.ConductingInstructions;
        }

        public override LabTestSample ConvertToEntity(LabTestSample entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.LabSampleTypeId = this.LabSampleTypeId;
            entity.LabTestBuilderId = this.LabTestBuilderId;
            entity.SampleInstructions = this.SampleInstructions;
            entity.ConductingInstructions = this.ConductingInstructions;
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastModifiedOn = DateTime.UtcNow;

            return entity;
        }
    }
}