using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class DoctorCategoryDTO : DTO<DoctorCategory, int>
    {
        public string Name { get; set; }

        public double Fee { get; set; }
        
        public DoctorCategoryStatus Status { get; set; }

        public string CreatedOn { get; set; }

        public override void ConvertFromEntity(DoctorCategory entity)
        {
            base.ConvertFromEntity(entity);
            this.Fee = entity.Fee;
            this.Name = entity.Name;
            this.Status = (DoctorCategoryStatus)entity.Status;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
        }

        public override DoctorCategory ConvertToEntity(DoctorCategory entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Fee = this.Fee;
            entity.Name = this.Name;
            entity.Status = (int)this.Status;

            return entity;
        }
    }
}