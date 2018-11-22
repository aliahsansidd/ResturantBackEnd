using System;
using System.ComponentModel;
using Recipe.Core.Base.Abstract;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class RateSheetDTO : DTO<RateSheet, int>
    {
        public string Name { get; set; }

        [DefaultValue(0)]
        public double Increment { get; set; }

        [DefaultValue(0)]
        public double Discount { get; set; }

        public RateSheetStatus Status { get; set; }

        public string CreatedOn { get; set; }

        public override void ConvertFromEntity(RateSheet entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Increment = entity.Increment;
            this.Discount = entity.Discount;
            this.Status = (RateSheetStatus)entity.Status;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
        }

        public override RateSheet ConvertToEntity(RateSheet entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Increment = this.Increment;
            entity.Discount = this.Discount;
            entity.Status = (int)this.Status;

            return entity;
        }
    }
}