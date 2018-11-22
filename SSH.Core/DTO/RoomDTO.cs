using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class RoomDTO : DTO<Room, int>
    {
        public int WardCategoryId { get; set; }

        public int FloorId { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public RoomStatus Status { get; set; }

        public override void ConvertFromEntity(Room entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.FloorId = entity.BuildingFloorId;
            this.Number = entity.Number;
            this.Status = (RoomStatus)entity.Status;
            this.WardCategoryId = entity.WardCategoryId;
        }

        public override Room ConvertToEntity(Room entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.BuildingFloorId = this.FloorId;
            //entity.Floor = this.Floor;
            entity.Number = this.Number;
            entity.Status = (int)this.Status;
            entity.WardCategoryId = this.WardCategoryId;

            return entity;
        }
    }
}