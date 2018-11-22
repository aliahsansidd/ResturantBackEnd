using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class RacksDTO : DTO<Racks, int>
    {
        public string Name { get; set; }

        public override void ConvertFromEntity(Racks entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
        }

        public override Racks ConvertToEntity(Racks entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            return entity;
        }
    }
}