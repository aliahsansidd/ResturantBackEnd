using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class WardCategoryDTO : DTO<WardCategory, int>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public double Price { get; set; }
        
        public WardCategoryStatus Status { get; set; }
        
        public string CreatedOn { get; set; }

        public override void ConvertFromEntity(WardCategory entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Price = entity.Price;
            this.Status = (WardCategoryStatus)entity.Status;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
            this.Type = entity.Type;
        }

        public override WardCategory ConvertToEntity(WardCategory entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Price = this.Price;
            entity.Status = (int)this.Status;
            entity.Type = this.Type;

            return entity;
        }
    }
}