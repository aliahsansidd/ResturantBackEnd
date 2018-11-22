using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class LabTestByEditor : EntityBase<int>
    {
        public LabTestByEditor()
        {    
        }

        public string EditorText { get; set; }

        public int Priority { get; set; }

        public int LabTestTemplateId { get; set; }

        public virtual LabTestTemplate LabTestTemplate { get; set; }
    }
}
