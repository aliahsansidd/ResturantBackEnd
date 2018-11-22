using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class LabInvoiceRepository : AuditableRepository<LabInvoice, int>, ILabInvoiceRepository
    {
        private ISSHRequestInfo requestInfo;

        public LabInvoiceRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
