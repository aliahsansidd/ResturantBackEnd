using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class LabDepartment : EntityBase<int>
    {
        public LabDepartment()
        {    
        }

        public string Name { get; set; }

        public int Status { get; set; }

        public virtual IList<LabDepartmentServices> LabDepartmentServices { get; set; }
    }
}
