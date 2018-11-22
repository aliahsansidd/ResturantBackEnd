using System;
using Recipe.Core.Base.Abstract;
using SSH.Common.Helper;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class LabTestInventoryAllocationDTO : DTO<LabTestInventoryAllocation, int>
    {
        public int Quantity { get; set; }

        public int LabTestBuilderId { get; set; }

        public override void ConvertFromEntity(LabTestInventoryAllocation entity)
        {
            base.ConvertFromEntity(entity);
            this.Quantity = entity.Quantity;
            this.LabTestBuilderId = entity.LabTestBuilderId;
        }

        public override LabTestInventoryAllocation ConvertToEntity(LabTestInventoryAllocation entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Quantity = this.Quantity;
            entity.LabTestBuilderId = this.LabTestBuilderId;

            return entity;
        }
    }
}