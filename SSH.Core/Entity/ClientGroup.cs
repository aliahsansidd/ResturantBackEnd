using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class ClientGroup : EntityBase<int>
    {
        public ClientGroup()
        {    
        }
        
        public string Name { get; set; }

        public string Remarks { get; set; }

        public int Status { get; set; }

        public virtual IList<ClientType> ClientType { get; set; }
    }
}
