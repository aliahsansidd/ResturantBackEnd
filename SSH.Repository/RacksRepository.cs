using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class RacksRepository : AuditableRepository<Racks, int>, IRacksRepository
    {
        private ISSHRequestInfo requestInfo;

        public RacksRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }

        protected override IQueryable<Racks> DefaultListQuery
        {
            get
            {
                return base.DefaultListQuery;
            }
        }

        protected override IQueryable<Racks> DefaultSingleQuery
        {
            get
            {
                return base.DefaultListQuery;
            }
        }
    }
}
