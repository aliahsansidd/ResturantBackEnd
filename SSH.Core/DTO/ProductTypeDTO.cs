using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class ProductTypeDTO : DTO<ProductType, int>
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public override void ConvertFromEntity(ProductType entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.ShortName = entity.ShortName;
        }

        public override ProductType ConvertToEntity(ProductType entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.ShortName = this.ShortName;
            return entity;
        }
    }
}