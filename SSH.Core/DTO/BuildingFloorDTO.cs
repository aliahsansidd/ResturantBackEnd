using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class BuildingFloorDTO : DTO<BuildingFloor, int>
    {
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public CommonActiveStatus Status { get; set; }
        
        public override void ConvertFromEntity(BuildingFloor entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.CreatedOn = entity.CreatedOn;
            this.Status = (CommonActiveStatus)entity.Status;   
        }

        public override BuildingFloor ConvertToEntity(BuildingFloor entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Status = (int)this.Status;
            
            return entity;
        }
    }
}