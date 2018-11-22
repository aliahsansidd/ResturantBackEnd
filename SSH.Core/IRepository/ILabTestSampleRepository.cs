﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Recipe.Core.Base.Interface;
using SSH.Core.DTO;
using SSH.Core.Entity;

namespace SSH.Core.IRepository
{
    public interface ILabTestSampleRepository : IRepository<LabTestSample, int>
    {
    }
}