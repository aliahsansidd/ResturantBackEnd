using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class Organization : EntityBase<int>
    {
        public Organization()
        {    
        }

        public int GroupOfCompaniesID { get; set; }

        public virtual GroupOfCompanies GroupOfCompanies { get; set; }

        public string Name { get; set; }

        public string ShortCode { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string BaseCurrency { get; set; }

        public virtual IList<Lisence> Lisence { get; set; }

        public virtual IList<OrganizationalDivision> OrganizationalDivision { get; set; }
    }
}
