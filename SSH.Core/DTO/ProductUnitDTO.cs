using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class ProductUnitDTO : DTO<ProductUnit, int>
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public override void ConvertFromEntity(ProductUnit entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.ShortName = entity.ShortName;
        }

        public override ProductUnit ConvertToEntity(ProductUnit entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.ShortName = this.ShortName;
            return entity;
        }
    }
}