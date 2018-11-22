using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class Driver : EntityBase<int>
    {
        public Driver()
        {
        }
        
        public string Name { get; set; }

        public string Picture { get; set; }

        public string Cell { get; set; }

        public string Address { get; set; }

        public string CNIC { get; set; }

        public string LicenseNo { get; set; }

        public int Status { get; set; }
        
    }
}
