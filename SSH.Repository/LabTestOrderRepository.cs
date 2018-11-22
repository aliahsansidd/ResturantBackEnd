using System.Data.Entity;
using System.Linq;
using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class LabTestOrderRepository : AuditableRepository<LabTestOrder, int>, ILabTestOrderRepository
    {
        private ISSHRequestInfo requestInfo;

        public LabTestOrderRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }

        protected override IQueryable<LabTestOrder> DefaultListQuery
        {
            get
            {
                return base.DefaultListQuery
                    .Include(x => x.LabTestOrderDetail);
            }
        }

        protected override IQueryable<LabTestOrder> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery
                    .Include(x => x.LabTestOrderDetail);
            }
        }
    }
}
