using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class BrandDTO : DTO<Brand, int>
    {
        public string Name { get; set; }

        public override void ConvertFromEntity(Brand entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
        }

        public override Brand ConvertToEntity(Brand entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            return entity;
        }
    }
}