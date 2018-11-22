using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class OrganizationDTO : DTO<Organization, int>
    {
        public int GroupOfCompaniesID { get; set; }

        public string Name { get; set; }

        public string ShortCode { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string BaseCurrency { get; set; }

        public override void ConvertFromEntity(Organization entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.ShortCode = entity.ShortCode;
            this.Email = entity.Email;
            this.Address = entity.Address;
            this.BaseCurrency = entity.BaseCurrency;
            this.GroupOfCompaniesID = entity.GroupOfCompaniesID;
        }

        public override Organization ConvertToEntity(Organization entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.GroupOfCompaniesID = this.GroupOfCompaniesID;
            entity.Name = this.Name;
            entity.ShortCode = this.ShortCode;
            entity.Email = this.Email;
            entity.Address = this.Address;
            entity.BaseCurrency = this.BaseCurrency;

            return entity;
        }
    }
}