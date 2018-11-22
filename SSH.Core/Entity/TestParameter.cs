using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class TestParameter : EntityBase<int>
    {
        public TestParameter()
        {    
        }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
    }
}
