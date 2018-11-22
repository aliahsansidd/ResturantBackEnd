using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class LabDepartmentServices : EntityBase<int>
    {
        public LabDepartmentServices()
        {    
        }

        public int LabDepartmentId { get; set; }

        public string Name { get; set; }

        public int Status { get; set; }

        public virtual LabDepartment LabDepartment { get; set; }

        public virtual IList<LabTestBuilder> LabTestBuilder { get; set; }
    }
}
