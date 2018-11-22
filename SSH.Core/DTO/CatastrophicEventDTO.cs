using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class CatastrophicEventDTO : DTO<CatastrophicEvent, int>
    {
        public string Name { get; set; }

        public string Place { get; set; }

        public string Description { get; set; }

        public DateTime EventDate { get; set; }

        public CommonActiveStatus Status { get; set; }
        
        public override void ConvertFromEntity(CatastrophicEvent entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Place = entity.Place;
            this.Description = entity.Description;
            this.EventDate = entity.EventDate;
            this.Status = (CommonActiveStatus)entity.Status;   
        }

        public override CatastrophicEvent ConvertToEntity(CatastrophicEvent entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Place = this.Place;
            entity.Description = this.Description;
            entity.EventDate = this.EventDate;
            entity.Status = (int)this.Status;
            
            return entity;
        }
    }
}