using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class BrandRepository : AuditableRepository<Brand, int>, IBrandRepository
    {
        private ISSHRequestInfo requestInfo;

        public BrandRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }

        protected override IQueryable<Brand> DefaultListQuery
        {
            get
            {
                return base.DefaultListQuery;
            }
        }

        protected override IQueryable<Brand> DefaultSingleQuery
        {
            get
            {
                return base.DefaultListQuery;
            }
        }
    }
}
