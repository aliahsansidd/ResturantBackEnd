using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class Bed : EntityBase<int>
    {
        public Bed()
        {
        }

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }

        public string BedNo { get; set; }

        public string Note { get; set; }

        public bool IsFunctional { get; set; }

        public int Status { get; set; }

        public virtual IList<BedAllocation> BedAllocations { get; set; }
    }
}
