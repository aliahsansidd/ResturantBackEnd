using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class ProductChemicalDTO : DTO<ProductChemical, int>
    {
        public string Name { get; set; }

        public override void ConvertFromEntity(ProductChemical entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
        }

        public override ProductChemical ConvertToEntity(ProductChemical entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            return entity;
        }
    }
}