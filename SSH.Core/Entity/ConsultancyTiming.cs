using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class ConsultancyTiming : EntityBase<int>
    {
        public ConsultancyTiming()
        {    
        }

        public string Name { get; set; }

        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        public string Days { get; set; }

        public int Status { get; set; }
    }
}
