using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class LabTestTemplate : EntityBase<int>
    {
        public LabTestTemplate()
        {    
        }

        public string Name { get; set; }

        public string Code { get; set; }

        public string TemplateIsByValueOrByEditor { get; set; }

        public virtual IList<LabTestBuilder> LabTestBuilder { get; set; }

        public virtual IList<LabTestByValue> LabTestByValue { get; set; }

        public virtual IList<LabTestByEditor> LabTestByEditor { get; set; }
    }
}
