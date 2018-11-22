using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class ProductCategoryDTO : DTO<ProductCategory, int>
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public override void ConvertFromEntity(ProductCategory entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.ShortName = entity.ShortName;
        }

        public override ProductCategory ConvertToEntity(ProductCategory entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.ShortName = this.ShortName;
            return entity;
        }
    }
}