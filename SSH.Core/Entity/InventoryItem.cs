using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class InventoryItem : EntityBase<int>
    {
        public InventoryItem()
        {    
        }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public string ItemMeasureIn { get; set; }

        public int ItemLimitationQuantity { get; set; }

        public int Status { get; set; }

        public int InventoryCategoryId { get; set; }

        public virtual InventoryCategory InventoryCategory { get; set; }
    }
}
