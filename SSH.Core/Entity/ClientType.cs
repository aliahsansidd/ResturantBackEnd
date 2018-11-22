using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class ClientType : EntityBase<int>
    {
        public ClientType()
        {    
        }

        public string Name { get; set; }

        public string Remarks { get; set; }

        public int Status { get; set; }

        public int ClientGroupID { get; set; }

        public virtual ClientGroup ClientGroup { get; set; }
    }
}
