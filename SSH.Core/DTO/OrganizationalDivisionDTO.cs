using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class OrganizationalDivisionDTO : DTO<OrganizationalDivision, int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ShortCode { get; set; }

        public int OrganizationID { get; set; }

        public CommonActiveStatus Status { get; set; }
        
        public override void ConvertFromEntity(OrganizationalDivision entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Description = entity.Description;
            this.ShortCode = entity.ShortCode;
            this.OrganizationID = entity.OrganizationID;
        }

        public override OrganizationalDivision ConvertToEntity(OrganizationalDivision entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Description = this.Description;
            entity.ShortCode = this.ShortCode;
            entity.OrganizationID = this.OrganizationID;
            return entity;
        }
    }
}