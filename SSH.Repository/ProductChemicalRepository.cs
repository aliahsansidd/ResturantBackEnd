using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class ProductChemicalRepository : AuditableRepository<ProductChemical, int>, IProductChemicalRepository
    {
        private ISSHRequestInfo requestInfo;

        public ProductChemicalRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }

        protected override IQueryable<ProductChemical> DefaultListQuery
        {
            get
            {
                return base.DefaultListQuery;
            }
        }

        protected override IQueryable<ProductChemical> DefaultSingleQuery
        {
            get
            {
                return base.DefaultListQuery;
            }
        }
    }
}
