using System;
using Recipe.Core.Base.Abstract;
using SSH.Common.Helper;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class TestParameterDTO : DTO<TestParameter, int>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string CreatedOn { get; set; }

        public override void ConvertFromEntity(TestParameter entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Code = entity.Code;
            this.Description = entity.Description;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
        }

        public override TestParameter ConvertToEntity(TestParameter entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Code = this.Code;
            entity.Description = this.Description;

            return entity;
        }
    }
}