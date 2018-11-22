﻿using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class ProductMeasurementUnitDTO : DTO<ProductMeasurementUnit, int>
    {
        public string Name { get; set; }

        public override void ConvertFromEntity(ProductMeasurementUnit entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
        }

        public override ProductMeasurementUnit ConvertToEntity(ProductMeasurementUnit entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            return entity;
        }
    }
}