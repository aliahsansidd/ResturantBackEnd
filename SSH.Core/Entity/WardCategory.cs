using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class WardCategory : EntityBase<int>
    {
        public WardCategory()
        {    
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public double Price { get; set; }
        
        public int Status { get; set; }

        public virtual IList<Room> Room { get; set; }

        public virtual IList<BedAllocation> BedAllocation { get; set; }
    }
}
