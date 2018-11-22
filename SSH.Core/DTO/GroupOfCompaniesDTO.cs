using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class GroupOfCompaniesDTO : DTO<GroupOfCompanies, int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ShortCode { get; set; }

        public ClientGroupStatus Status { get; set; }
        
        public override void ConvertFromEntity(GroupOfCompanies entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Description = entity.Description;
            this.ShortCode = entity.ShortCode;
        }

        public override GroupOfCompanies ConvertToEntity(GroupOfCompanies entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Description = this.Description;
            entity.ShortCode = this.ShortCode;
            return entity;
        }
    }
}