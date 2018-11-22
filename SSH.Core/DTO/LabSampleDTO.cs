using System;
using System.Collections.Generic;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class LabSampleDTO : DTO<LabSample, int>
    {
        public int LabSampleTypeId { get; set; }

        public int LabTestBuilderId { get; set; }

        public int PatientId { get; set; }

        public bool IsPrefix { get; set; }

        public string PrefixOrPostfixName { get; set; }

        public LabSampleStatus SampleStatus { get; set; }

        public override void ConvertFromEntity(LabSample entity)
        {
            base.ConvertFromEntity(entity);
            this.LabSampleTypeId = entity.LabSampleTypeId;
            this.LabTestBuilderId = entity.LabTestBuilderId;
            this.PatientId = entity.PatientId;
            this.IsPrefix = entity.IsPrefix;
            this.PrefixOrPostfixName = entity.PrefixOrPostfixName;
            this.SampleStatus = (LabSampleStatus)entity.SampleStatus;  
        }

        public override LabSample ConvertToEntity(LabSample entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.LabSampleTypeId = this.LabSampleTypeId;
            entity.LabTestBuilderId = this.LabTestBuilderId;
            entity.PatientId = this.PatientId;
            entity.IsPrefix = this.IsPrefix;
            entity.PrefixOrPostfixName = this.PrefixOrPostfixName;
            entity.SampleStatus = (int)this.SampleStatus;
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastModifiedOn = DateTime.UtcNow;

            return entity;
        }
    }
}