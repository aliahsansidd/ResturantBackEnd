using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class BuildingMaterialCategory : EntityBase<int>
    {
        public BuildingMaterialCategory()
        {    
        }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public int Status { get; set; }

        public virtual IList<BuildingMaterial> BuildingMaterial { get; set; }
    }
}
