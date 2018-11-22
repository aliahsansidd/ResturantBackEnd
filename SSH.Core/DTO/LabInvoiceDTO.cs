using System;
using System.Collections.Generic;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class LabInvoiceDTO : DTO<LabInvoice, int>
    {
        public int LabTestOrderId { get; set; }
        
        public double TotalAmount { get; set; }

        public double ReceivedAmount { get; set; }

        public double DueAmount { get; set; }

        public int IncomeGroupId { get; set; }

        public bool IsBillPaid { get; set; }

        public double Tax { get; set; }

        public IList<LabInvoiceDetailDTO> LabInvoiceDetaildto { get; set; }

        public override void ConvertFromEntity(LabInvoice entity)
        {
            base.ConvertFromEntity(entity);
            this.LabTestOrderId = entity.LabTestOrderId;
            this.TotalAmount = entity.TotalAmount;
            this.ReceivedAmount = entity.ReceivedAmount;
            this.DueAmount = entity.DueAmount;
            this.IsBillPaid = entity.IsBillPaid;
            this.Tax = entity.Tax;
            this.IncomeGroupId = entity.IncomeGroupId;
            this.LabInvoiceDetaildto = entity.LabInvoiceDetail.Count != 0 ? LabInvoiceDetailDTO.ConvertEntityListToDTOList<LabInvoiceDetailDTO>(entity.LabInvoiceDetail) : null;
        }

        public override LabInvoice ConvertToEntity(LabInvoice entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.LabTestOrderId = this.LabTestOrderId;
            entity.TotalAmount = this.TotalAmount;
            entity.ReceivedAmount = this.ReceivedAmount;
            entity.DueAmount = this.DueAmount;
            entity.IsBillPaid = this.IsBillPaid;
            entity.Tax = this.Tax;
            entity.IncomeGroupId = this.IncomeGroupId;
            entity.LabInvoiceDetail = this.LabInvoiceDetaildto.Count != 0 ? LabInvoiceDetailDTO.ConvertDTOListToEntity(this.LabInvoiceDetaildto) : null;
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastModifiedOn = DateTime.UtcNow;

            return entity;
        }
    }
}