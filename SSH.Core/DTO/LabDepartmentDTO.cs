using System;
using Recipe.Core.Base.Abstract;
using SSH.Common.Helper;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class LabDepartmentDTO : DTO<LabDepartment, int>
    {
        public string Name { get; set; }

        public LabDepartmentStatus Status { get; set; }

        public string CreatedOn { get; set; }

        public override void ConvertFromEntity(LabDepartment entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Status = (LabDepartmentStatus)entity.Status;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
        }

        public override LabDepartment ConvertToEntity(LabDepartment entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Status = (int)this.Status;

            return entity;
        }
    }
}