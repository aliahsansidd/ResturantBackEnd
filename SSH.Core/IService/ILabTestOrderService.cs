﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Recipe.Common.Helper;
using Recipe.Core.Attribute;
using Recipe.Core.Base.Interface;
using Recipe.Core.Enum;
using SSH.Core.DTO;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.IService
{
    public interface ILabTestOrderService : IService<LabTestOrderDTO, int>
    {
    }
}
