using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class CompanyAccountLevel : EntityBase<int>
    {
        public CompanyAccountLevel()
        {    
        }

        public string Code { get; set; }

        public string Description { get; set; }

        public int Order { get; set; }

        public int NoOfDigits { get; set; }

        public virtual IList<CompanyAccount> CompanyAccount { get; set; }
    }
}
