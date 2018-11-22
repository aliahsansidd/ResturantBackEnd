using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class BuildingMaterial : EntityBase<int>
    {
        public BuildingMaterial()
        {    
        }

        public int BuildingMaterialCategoryId { get; set; }

        public virtual BuildingMaterialCategory BuildingMaterialCategory { get; set; }

        public string EquipmentName { get; set; }

        public string EquipmentCode { get; set; }

        public string VendorName { get; set; }

        public string ContactPerson { get; set; }

        public string Contact1 { get; set; }

        public string Contact2 { get; set; }

        public string Contact3 { get; set; }

        public string Address { get; set; }

        public DateTime PurchaseDate { get; set; }

        public string WarrantyType { get; set; }

        public DateTime WarrantyExpires { get; set; }

        public DateTime ScheduledMaintenance { get; set; }
    }
}
