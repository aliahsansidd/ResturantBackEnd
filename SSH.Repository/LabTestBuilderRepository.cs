using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class LabTestBuilderRepository : AuditableRepository<LabTestBuilder, int>, ILabTestBuilderRepository
    {
        private ISSHRequestInfo requestInfo;

        public LabTestBuilderRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }

        protected override IQueryable<LabTestBuilder> DefaultListQuery
        {
            get
            {
                return base.DefaultListQuery
                    .Include(x => x.LabTestSample);
            }
        }

        protected override IQueryable<LabTestBuilder> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery
                    .Include(x => x.LabTestSample);
            }
        }
    }
}
