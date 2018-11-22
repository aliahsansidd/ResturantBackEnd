using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class InventoryCategory : EntityBase<int>
    {
        public InventoryCategory()
        {    
        }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public virtual IList<InventoryItem> InventoryItem { get; set; }
    }
}
