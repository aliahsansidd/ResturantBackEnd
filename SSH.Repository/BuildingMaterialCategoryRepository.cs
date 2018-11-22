using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class BuildingMaterialCategoryRepository : AuditableRepository<BuildingMaterialCategory, int>, IBuildingMaterialCategoryRepository
    {
        private ISSHRequestInfo requestInfo;

        public BuildingMaterialCategoryRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
