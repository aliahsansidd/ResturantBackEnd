using System;
using System.Threading.Tasks;
using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class BedAllocationRepository : AuditableRepository<BedAllocation, int>, IBedAllocationRepository
    {
        private ISSHRequestInfo requestInfo;

        public BedAllocationRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
