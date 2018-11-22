using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Recipe.Common.Helper;
using Recipe.Core.Base.Generic;
using SSH.Common.Helper;
using SSH.Core.Constant;
using SSH.Core.DTO;
using SSH.Core.Entity;
using SSH.Core.Enum;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class LabOutSourceRepository : AuditableRepository<LabOutSource, int>, ILabOutSourceRepository
    {
        private ISSHRequestInfo requestInfo;

        public LabOutSourceRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
