using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class LabTestByEditorRepository : AuditableRepository<LabTestByEditor, int>, ILabTestByEditorRepository
    {
        private ISSHRequestInfo requestInfo;

        public LabTestByEditorRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
