using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class ProductMeasurementUnitRepository : AuditableRepository<ProductMeasurementUnit, int>, IProductMeasurementUnitRepository
    {
        private ISSHRequestInfo requestInfo;

        public ProductMeasurementUnitRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }

        protected override IQueryable<ProductMeasurementUnit> DefaultListQuery
        {
            get
            {
                return base.DefaultListQuery;
            }
        }

        protected override IQueryable<ProductMeasurementUnit> DefaultSingleQuery
        {
            get
            {
                return base.DefaultListQuery;
            }
        }
    }
}
