using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class OrganizationalDivisionDepartment : EntityBase<int>
    {
        public OrganizationalDivisionDepartment()
        {
        }

        public int OrganizationDivisionID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ShortCode { get; set; }

        public virtual IList<OrganizationalDivision> OrganizationalDivision { get; set; }
    }
}
