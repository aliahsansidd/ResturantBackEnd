using System;
using System.ComponentModel;
using Recipe.Core.Base.Abstract;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class InventoryCategoryDTO : DTO<InventoryCategory, int>
    {
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public InventoryCategoryStatus Status { get; set; }

        public override void ConvertFromEntity(InventoryCategory entity)
        {
            base.ConvertFromEntity(entity);
            this.CategoryName = entity.CategoryName;
            this.Description = entity.Description;
            this.Status = (InventoryCategoryStatus)entity.Status;
        }

        public override InventoryCategory ConvertToEntity(InventoryCategory entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.CategoryName = this.CategoryName;
            entity.Description = this.Description;
            entity.Status = (int)this.Status;

            return entity;
        }
    }
}