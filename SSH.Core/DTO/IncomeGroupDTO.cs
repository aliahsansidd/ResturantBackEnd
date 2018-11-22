using System;
using Recipe.Core.Base.Abstract;
using SSH.Common.Helper;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class IncomeGroupDTO : DTO<IncomeGroup, int>
    {
        public string Description { get; set; }

        public IncomeGroupStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public override void ConvertFromEntity(IncomeGroup entity)
        {
            base.ConvertFromEntity(entity);
            this.Description = entity.Description;
            this.Status = (IncomeGroupStatus)entity.Status;
            this.CreatedOn = entity.CreatedOn;
        }

        public override IncomeGroup ConvertToEntity(IncomeGroup entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Description = this.Description;
            entity.Status = (int)this.Status;

            return entity;
        }
    }
}