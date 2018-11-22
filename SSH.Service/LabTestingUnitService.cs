using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recipe.Core.Base.Generic;
using SSH.Core.Constant;
using SSH.Core.DTO;
using SSH.Core.Entity;
using SSH.Core.Enum;
using SSH.Core.Extensions;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;
using SSH.Core.IService;

namespace SSH.Service
{
    public class LabTestingUnitService : Service<ILabTestingUnitRepository, LabTestingUnit, LabTestingUnitDTO, int>, ILabTestingUnitService
    {
        private ISSHRequestInfo requestInfo;
        private IExceptionHelper exceptionHelper;
        private ISSHUnitOfWork unitOfWork;

        public LabTestingUnitService(
            ISSHUnitOfWork unitOfWork,
            ISSHRequestInfo requestInfo,
            IExceptionHelper exceptionHelper)
            : base(unitOfWork, unitOfWork.LabTestingUnitRepository)
        {
            this.requestInfo = requestInfo;
            this.exceptionHelper = exceptionHelper;
            this.unitOfWork = unitOfWork;
        }
    }
}
