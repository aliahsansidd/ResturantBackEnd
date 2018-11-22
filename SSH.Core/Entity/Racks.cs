using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class Racks : EntityBase<int>
    {
        public string Name { get; set; }
    }
}
