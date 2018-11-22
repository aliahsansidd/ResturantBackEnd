using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class ProductTypeRepository : AuditableRepository<ProductType, int>, IProductTypeRepository
    {
        private ISSHRequestInfo requestInfo;

        public ProductTypeRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }

        protected override IQueryable<ProductType> DefaultListQuery
        {
            get
            {
                return base.DefaultListQuery;
            }
        }

        protected override IQueryable<ProductType> DefaultSingleQuery
        {
            get
            {
                return base.DefaultListQuery;
            }
        }
    }
}
