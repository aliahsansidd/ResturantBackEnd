using System;
using Recipe.Core.Base.Abstract;
using SSH.Common.Helper;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class LabDepartmentServicesDTO : DTO<LabDepartmentServices, int>
    {
        public string Name { get; set; }

        public LabDepartmentServicesStatus Status { get; set; }

        public int LabDepartmentId { get; set; }

        public string CreatedOn { get; set; }

        public override void ConvertFromEntity(LabDepartmentServices entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Status = (LabDepartmentServicesStatus)entity.Status;
            this.LabDepartmentId = entity.LabDepartmentId;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
        }

        public override LabDepartmentServices ConvertToEntity(LabDepartmentServices entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Status = (int)this.Status;
            entity.LabDepartmentId = this.LabDepartmentId;

            return entity;
        }
    }
}