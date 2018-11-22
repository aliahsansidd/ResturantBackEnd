using System;
using System.Collections.Generic;
using System.Linq;
using Recipe.Core.Base.Abstract;
using SSH.Common.Helper;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class LabTestBuilderDTO : DTO<LabTestBuilder, int>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string DependencyTests { get; set; }

        public string Remarks { get; set; }

        public double Price { get; set; }

        public bool IsSampleNeeded { get; set; }

        public bool IsResultEntry { get; set; }

        public bool IsConductionRequired { get; set; }

        public TimeSpan ConductingDuration { get; set; }

        public LabTestBuilderStatus Status { get; set; }

        public string CreatedOn { get; set; }

        public int LabDepartmentServicesId { get; set; }

        public int? LabTestTemplateId { get; set; }

        public int? LabOutSourceId { get; set; }

        public List<LabTestSampleDTO> LabTestSampleDto { get; set; }

        public override void ConvertFromEntity(LabTestBuilder entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Code = entity.Code;
            this.DependencyTests = entity.DependencyTests;
            this.Remarks = entity.Remarks;
            this.Price = entity.Price;
            this.IsSampleNeeded = entity.IsSampleNeeded;
            this.IsResultEntry = entity.IsResultEntry;
            this.IsConductionRequired = entity.IsConductionRequired;
            this.ConductingDuration = entity.ConductingDuration;
            this.Status = (LabTestBuilderStatus)entity.Status;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
            this.LabDepartmentServicesId = entity.LabDepartmentServicesId;
            this.LabTestTemplateId = entity.LabTestTemplateId != null ? entity.LabTestTemplateId : 0;
            this.LabOutSourceId = entity.LabOutSourceId != null ? entity.LabOutSourceId : 0;
            if (this.IsSampleNeeded == true)
            {
                // Assigning Samples to Test IF Sample Needed
                this.LabTestSampleDto = entity.LabTestSample != null ? LabTestSampleDTO.ConvertEntityListToDTOList<LabTestSampleDTO>(entity.LabTestSample) : null;
            }
        }

        public override LabTestBuilder ConvertToEntity(LabTestBuilder entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Code = this.Code;
            entity.DependencyTests = this.DependencyTests;
            entity.Remarks = this.Remarks;
            entity.Price = this.Price;
            entity.IsSampleNeeded = this.IsSampleNeeded;
            entity.IsResultEntry = this.IsResultEntry;
            entity.IsConductionRequired = this.IsConductionRequired;
            entity.ConductingDuration = this.ConductingDuration;
            entity.Status = (int)this.Status;
            entity.LabDepartmentServicesId = this.LabDepartmentServicesId;
            entity.LabTestTemplateId = (this.LabTestTemplateId != 0 && this.LabTestTemplateId != null) ? this.LabTestTemplateId : null;
            entity.LabOutSourceId = (this.LabOutSourceId != 0 && this.LabOutSourceId != null) ? this.LabOutSourceId : null;
            if (entity.IsSampleNeeded == true)
            {
                // Assigning Samples to Test IF Sample Needed
                entity.LabTestSample = this.LabTestSampleDto != null ?
                    this.LabTestSampleDto.Count() > 0 ? LabTestSampleDTO.ConvertDTOListToEntity(this.LabTestSampleDto) : null : null;
            }
            
            return entity;
        }
    }
}