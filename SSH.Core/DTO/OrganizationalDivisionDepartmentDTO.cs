using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class OrganizationalDivisionDepartmentDTO : DTO<OrganizationalDivisionDepartment, int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ShortCode { get; set; }

        public int OrganizationDivisionID { get; set; }

        public CommonActiveStatus Status { get; set; }
        
        public override void ConvertFromEntity(OrganizationalDivisionDepartment entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Description = entity.Description;
            this.ShortCode = entity.ShortCode;
            this.OrganizationDivisionID = entity.OrganizationDivisionID;
        }

        public override OrganizationalDivisionDepartment ConvertToEntity(OrganizationalDivisionDepartment entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Description = this.Description;
            entity.ShortCode = this.ShortCode;
            entity.OrganizationDivisionID = this.OrganizationDivisionID;
            return entity;
        }
    }
}