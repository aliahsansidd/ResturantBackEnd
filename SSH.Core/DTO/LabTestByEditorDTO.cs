using System;
using Recipe.Core.Base.Abstract;
using SSH.Common.Helper;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class LabTestByEditorDTO : DTO<LabTestByEditor, int>
    {
        public string EditorText { get; set; }

        public int Priority { get; set; }

        public int LabTestTemplateId { get; set; }

        public override void ConvertFromEntity(LabTestByEditor entity)
        {
            base.ConvertFromEntity(entity);
            this.EditorText = entity.EditorText;
            this.Priority = entity.Priority;
            this.LabTestTemplateId = entity.LabTestTemplateId;
        }

        public override LabTestByEditor ConvertToEntity(LabTestByEditor entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.EditorText = this.EditorText;
            entity.Priority = this.Priority;
            entity.LabTestTemplateId = this.LabTestTemplateId;
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastModifiedOn = DateTime.UtcNow;

            return entity;
        }
    }
}