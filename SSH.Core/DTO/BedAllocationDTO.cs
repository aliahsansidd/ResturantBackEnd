using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class BedAllocationDTO : DTO<BedAllocation, int>
    {
        public int PatientId { get; set; }

        public int WardCategoryId { get; set; }

        public int RoomId { get; set; }

        public int BedId { get; set; }

        public DateTime? AllocationDateTime { get; set; }

        public DateTime? DischargeDateTime { get; set; }

        public DateTime? TransferDateTime { get; set; }

        public string ReferenceNumber { get; set; }

        public string Reason { get; set; }

        public BedAllocationStatus Status { get; set; }

        public override void ConvertFromEntity(BedAllocation entity)
        {
            base.ConvertFromEntity(entity);
            this.AllocationDateTime = entity.AllocationDateTime.HasValue ? entity.AllocationDateTime.Value : (DateTime?)null;
            this.DischargeDateTime = entity.DischargeDateTime.HasValue ? entity.DischargeDateTime.Value : (DateTime?)null;
            this.PatientId = entity.PatientId;
            this.Reason = entity.Reason;
            this.ReferenceNumber = entity.ReferenceNumber;
            this.Status = (BedAllocationStatus)entity.Status;
            this.TransferDateTime = entity.TransferDateTime.HasValue ? entity.TransferDateTime.Value : (DateTime?)null;
            this.WardCategoryId = entity.WardCategoryId;
            this.RoomId = entity.RoomId;
            this.BedId = entity.BedId;
        }

        public override BedAllocation ConvertToEntity(BedAllocation entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.AllocationDateTime = this.AllocationDateTime;
            entity.DischargeDateTime = this.DischargeDateTime;
            entity.RoomId = this.RoomId;
            entity.BedId = this.BedId;
            entity.PatientId = this.PatientId;
            entity.Reason = this.Reason;
            entity.ReferenceNumber = this.ReferenceNumber;
            entity.Status = (int)this.Status;
            entity.TransferDateTime = this.TransferDateTime;
            entity.WardCategoryId = this.WardCategoryId;

            return entity;
        }
    }
}