using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class LabInvoiceDetailRepository : AuditableRepository<LabInvoiceDetail, int>, ILabInvoiceDetailRepository
    {
        private ISSHRequestInfo requestInfo;

        public LabInvoiceDetailRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
