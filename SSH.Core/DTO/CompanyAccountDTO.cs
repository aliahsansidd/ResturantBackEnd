using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class CompanyAccountDTO : DTO<CompanyAccount, int>
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public int CurrencyId { get; set; }

        public int CompanyAccountLevelId { get; set; }

        public override void ConvertFromEntity(CompanyAccount entity)
        {
            base.ConvertFromEntity(entity);
            this.Code = entity.Code;
            this.Description = entity.Description;
            this.CurrencyId = entity.CurrencyId;
            this.CompanyAccountLevelId = entity.CompanyAccountLevelId;
        }

        public override CompanyAccount ConvertToEntity(CompanyAccount entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Code = this.Code;
            entity.Description = this.Description;
            entity.CurrencyId = this.CurrencyId;
            entity.CompanyAccountLevelId = this.CompanyAccountLevelId;

            return entity;
        }
    }
}