using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class BuildingMaterialCategoryDTO : DTO<BuildingMaterialCategory, int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public BuildingMaterialCategoryStatus Status { get; set; }

        public string CreatedOn { get; set; }

        public override void ConvertFromEntity(BuildingMaterialCategory entity)
        {
            base.ConvertFromEntity(entity);
            this.Description = entity.Description;
            this.Name = entity.Name;
            this.Status = (BuildingMaterialCategoryStatus)entity.Status;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
        }

        public override BuildingMaterialCategory ConvertToEntity(BuildingMaterialCategory entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Description = this.Description;
            entity.Name = this.Name;
            entity.Status = (int)this.Status;

            return entity;
        }
    }
}