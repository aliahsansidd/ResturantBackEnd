using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class CompanyAccount : EntityBase<int>
    {
        public CompanyAccount()
        {    
        }

        public string Code { get; set; }

        public string Description { get; set; }

        public int CurrencyId { get; set; }

        public int CompanyAccountLevelId { get; set; }

        public virtual CompanyAccountLevel CompanyAccountLevel { get; set; }
    }
}
