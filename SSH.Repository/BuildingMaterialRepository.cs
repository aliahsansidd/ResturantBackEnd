using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class BuildingMaterialRepository : AuditableRepository<BuildingMaterial, int>, IBuildingMaterialRepository
    {
        private ISSHRequestInfo requestInfo;

        public BuildingMaterialRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
