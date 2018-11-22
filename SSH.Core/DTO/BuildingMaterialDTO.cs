using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class BuildingMaterialDTO : DTO<BuildingMaterial, int>
    {
        public int BuildingMaterialCategoryId { get; set; }
        
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

        public string CreatedOn { get; set; }

        public override void ConvertFromEntity(BuildingMaterial entity)
        {
            base.ConvertFromEntity(entity);
            this.Address = entity.Address;
            this.BuildingMaterialCategoryId = entity.BuildingMaterialCategoryId;
            this.Contact1 = entity.Contact1;
            this.Contact2 = entity.Contact2;
            this.Contact3 = entity.Contact3;
            this.ContactPerson = entity.ContactPerson;
            this.EquipmentCode = entity.EquipmentCode;
            this.EquipmentName = entity.EquipmentName;
            this.PurchaseDate = entity.PurchaseDate;
            this.ScheduledMaintenance = entity.ScheduledMaintenance;
            this.VendorName = entity.VendorName;
            this.WarrantyExpires = entity.WarrantyExpires;
            this.WarrantyType = entity.WarrantyType;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
        }

        public override BuildingMaterial ConvertToEntity(BuildingMaterial entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Address = this.Address;
            entity.BuildingMaterialCategoryId = this.BuildingMaterialCategoryId;
            entity.Contact1 = this.Contact1;
            entity.Contact2 = this.Contact2;
            entity.Contact3 = this.Contact3;
            entity.ContactPerson = this.ContactPerson;
            entity.EquipmentCode = this.EquipmentCode;
            entity.EquipmentName = this.EquipmentName;
            entity.PurchaseDate = this.PurchaseDate;
            entity.ScheduledMaintenance = this.ScheduledMaintenance;
            entity.VendorName = this.VendorName;
            entity.WarrantyExpires = this.WarrantyExpires;
            entity.WarrantyType = this.WarrantyType;

            return entity;
        }
    }
}