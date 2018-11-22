using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class CatastrophicEvent : EntityBase<int>
    {
        public CatastrophicEvent()
        {    
        }

        public string Name { get; set; }

        public string Place { get; set; }

        public string Description { get; set; }

        public DateTime EventDate { get; set; }

        public int Status { get; set; }

        public virtual IList<AccidentAndEmergency> AccidentAndEmergency { get; set; }
    }
}
