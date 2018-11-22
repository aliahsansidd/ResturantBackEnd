using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class LabInvoiceDetailDTO : DTO<LabInvoiceDetail, int>
    {
        public int LabInvoiceId { get; set; }

        public int LabTestBuilderId { get; set; }

        public double TestUnitPrice { get; set; }

        public override void ConvertFromEntity(LabInvoiceDetail entity)
        {
            base.ConvertFromEntity(entity);
            this.LabInvoiceId = entity.LabInvoiceId;
            this.LabTestBuilderId = entity.LabTestBuilderId;
            this.TestUnitPrice = entity.TestUnitPrice;
        }

        public override LabInvoiceDetail ConvertToEntity(LabInvoiceDetail entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.LabInvoiceId = this.LabInvoiceId;
            entity.LabTestBuilderId = this.LabTestBuilderId;
            entity.TestUnitPrice = this.TestUnitPrice;
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastModifiedOn = DateTime.UtcNow;

            return entity;
        }
    }
}