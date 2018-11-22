using System;
using Recipe.Core.Base.Abstract;
using SSH.Common.Helper;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class LabTestingUnitDTO : DTO<LabTestingUnit, int>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string CreatedOn { get; set; }

        public override void ConvertFromEntity(LabTestingUnit entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Code = entity.Code;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
        }

        public override LabTestingUnit ConvertToEntity(LabTestingUnit entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Code = this.Code;

            return entity;
        }
    }
}