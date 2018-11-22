using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class OPDRegistration : EntityBase<int>
    {
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }
        
        public int Status { get; set; }
    }
}
