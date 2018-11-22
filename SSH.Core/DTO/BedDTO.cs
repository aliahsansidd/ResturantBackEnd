using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class BedDTO : DTO<Bed, int>
    {
        public int RoomId { get; set; }

        public string BedNo { get; set; }

        public string Note { get; set; }

        public bool IsFunctional { get; set; }

        public BedStatus Status { get; set; }

        public override void ConvertFromEntity(Bed entity)
        {
            base.ConvertFromEntity(entity);
            this.BedNo = entity.BedNo;
            this.IsFunctional = entity.IsFunctional;
            this.Note = entity.Note;
            this.RoomId = entity.RoomId;
            this.Status = (BedStatus)entity.Status;
        }

        public override Bed ConvertToEntity(Bed entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.BedNo = this.BedNo;
            entity.IsFunctional = this.IsFunctional;
            entity.Note = this.Note;
            entity.RoomId = this.RoomId;
            entity.Status = (int)this.Status;

            return entity;
        }
    }
}