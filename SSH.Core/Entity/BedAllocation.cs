using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class BedAllocation : EntityBase<int>
    {
        public BedAllocation()
        {
        }

        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        public int WardCategoryId { get; set; }

        public virtual WardCategory WardCategory { get; set; }

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }

        public int BedId { get; set; }

        public virtual Bed Bed { get; set; }

        public DateTime? AllocationDateTime { get; set; }

        public DateTime? DischargeDateTime { get; set; }

        public DateTime? TransferDateTime { get; set; }

        public string ReferenceNumber { get; set; }

        public string Reason { get; set; }

        public int Status { get; set; }
    }
}