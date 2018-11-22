using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class CompanyAccountLevelDTO : DTO<CompanyAccountLevel, int>
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public int Order { get; set; }

        public int NoOfDigits { get; set; }

        public override void ConvertFromEntity(CompanyAccountLevel entity)
        {
            base.ConvertFromEntity(entity);
            this.Code = entity.Code;
            this.Description = entity.Description;
            this.Order = entity.Order;
            this.NoOfDigits = entity.NoOfDigits;
        }

        public override CompanyAccountLevel ConvertToEntity(CompanyAccountLevel entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Code = this.Code;
            entity.Description = this.Description;
            entity.Order = this.Order;
            entity.NoOfDigits = this.NoOfDigits;

            return entity;
        }
    }
}