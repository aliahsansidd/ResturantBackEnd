using System.Data.Entity;
using System.Linq;
using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class LabTestTemplateRepository : AuditableRepository<LabTestTemplate, int>, ILabTestTemplateRepository
    {
        private ISSHRequestInfo requestInfo;

        public LabTestTemplateRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }

        protected override IQueryable<LabTestTemplate> DefaultListQuery
        {
            get
            {
                return base.DefaultListQuery
                    .Include(x => x.LabTestByValue)
                    .Include(x => x.LabTestByEditor);
            }
        }

        protected override IQueryable<LabTestTemplate> DefaultSingleQuery
        {
            get
            {
                return base.DefaultListQuery
                    .Include(x => x.LabTestByValue)
                    .Include(x => x.LabTestByEditor);
            }
        }
    }
}
