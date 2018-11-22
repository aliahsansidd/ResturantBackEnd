using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class BuildingFloorRepository : AuditableRepository<BuildingFloor, int>, IBuildingFloorRepository
    {
        private ISSHRequestInfo requestInfo;

        public BuildingFloorRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
