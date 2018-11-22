using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class Room : EntityBase<int>
    {
        public Room()
        {
        }

        public int WardCategoryId { get; set; }

        public virtual WardCategory WardCategory { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public int Status { get; set; }

        public virtual IList<Bed> Bed { get; set; }

        public int BuildingFloorId { get; set; }

        public virtual BuildingFloor BuildingFloor { get; set; }

        public virtual IList<BedAllocation> BedAllocations { get; set; }
    }
}
