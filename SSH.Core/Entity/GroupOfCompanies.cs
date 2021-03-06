﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class GroupOfCompanies : EntityBase<int>
    {
        public GroupOfCompanies()
        {    
        }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public string ShortCode { get; set; }

        public virtual IList<Organization> Organization { get; set; }
    }
}
