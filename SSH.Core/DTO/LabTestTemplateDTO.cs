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
    public class LabTestTemplateDTO : DTO<LabTestTemplate, int>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string TemplateIsByValueOrByEditor { get; set; }

        public List<LabTestByValueDTO> LabTestByValuedto { get; set; }

        public List<LabTestByEditorDTO> LabTestByEditordto { get; set; }

        public override void ConvertFromEntity(LabTestTemplate entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Code = entity.Code;
            this.TemplateIsByValueOrByEditor = entity.TemplateIsByValueOrByEditor;
            this.LabTestByValuedto = (entity.TemplateIsByValueOrByEditor == "ByValue" || entity.TemplateIsByValueOrByEditor == "Both") ?
                entity.LabTestByValue != null ? LabTestByValueDTO.ConvertEntityListToDTOList<LabTestByValueDTO>(entity.LabTestByValue) : null : null;
            this.LabTestByEditordto = (entity.TemplateIsByValueOrByEditor == "ByEditor" || entity.TemplateIsByValueOrByEditor == "Both") ?
                entity.LabTestByEditor != null ? LabTestByEditorDTO.ConvertEntityListToDTOList<LabTestByEditorDTO>(entity.LabTestByEditor) : null : null;
        }

        public override LabTestTemplate ConvertToEntity(LabTestTemplate entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Code = this.Code;
            entity.TemplateIsByValueOrByEditor = this.TemplateIsByValueOrByEditor;
            entity.LabTestByValue = (this.TemplateIsByValueOrByEditor == "ByValue" || this.TemplateIsByValueOrByEditor == "Both") ?
                this.LabTestByValuedto != null ? this.LabTestByValuedto.Count() > 0 ? LabTestByValueDTO.ConvertDTOListToEntity(this.LabTestByValuedto) : null : null : null;
            entity.LabTestByEditor = (this.TemplateIsByValueOrByEditor == "ByEditor" || this.TemplateIsByValueOrByEditor == "Both") ?
                this.LabTestByEditordto != null ? this.LabTestByEditordto.Count() > 0 ? LabTestByEditorDTO.ConvertDTOListToEntity(this.LabTestByEditordto) : null : null : null; 

            return entity;
        }
    }
}