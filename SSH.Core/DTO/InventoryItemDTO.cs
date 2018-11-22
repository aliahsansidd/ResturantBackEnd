using System;
using System.ComponentModel;
using Recipe.Core.Base.Abstract;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class InventoryItemDTO : DTO<InventoryItem, int>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public string ItemMeasureIn { get; set; }

        public int ItemLimitationQuantity { get; set; }

        public int InventoryCategoryId { get; set; }

        public InventoryItemStatus Status { get; set; }

        public override void ConvertFromEntity(InventoryItem entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Code = entity.Code;
            this.Description = entity.Description;
            this.Quantity = entity.Quantity;
            this.UnitPrice = entity.UnitPrice;
            this.ItemMeasureIn = entity.ItemMeasureIn;
            this.ItemLimitationQuantity = entity.ItemLimitationQuantity;
            this.InventoryCategoryId = entity.InventoryCategoryId;
            this.Status = (InventoryItemStatus)entity.Status;
        }

        public override InventoryItem ConvertToEntity(InventoryItem entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Code = this.Code;
            entity.Description = this.Description;
            entity.Quantity = this.Quantity;
            entity.UnitPrice = this.UnitPrice;
            entity.ItemMeasureIn = this.ItemMeasureIn;
            entity.ItemLimitationQuantity = this.ItemLimitationQuantity;
            entity.InventoryCategoryId = this.InventoryCategoryId;
            entity.Status = (int)this.Status;

            return entity;
        }
    }
}