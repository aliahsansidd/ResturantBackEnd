using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class OPD : EntityBase<int>
    {
        public OPD()
        {    
        }

        public string Name { get; set; }

        public bool IsVital { get; set; }

        public string Description { get; set; }

        public virtual IList<DoctorOPD> DoctorOPD { get; set; }
    }
}
