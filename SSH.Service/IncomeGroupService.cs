using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recipe.Common.Helper;
using Recipe.Core.Base.Generic;
using SSH.Common.Helper;
using SSH.Core.Constant;
using SSH.Core.DTO;
using SSH.Core.Entity;
using SSH.Core.Enum;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;
using SSH.Core.IService;

namespace SSH.Service
{
    public class IncomeGroupService : Service<IIncomeGroupRepository, IncomeGroup, IncomeGroupDTO, int>, IIncomeGroupService
    {
        private ISSHUnitOfWork unitOfWork;
        private IExceptionHelper exceptionHelper;
        private ISSHRequestInfo requestInfo;

        public IncomeGroupService(ISSHUnitOfWork unitOfWork, IExceptionHelper exceptionHelper, ISSHRequestInfo requestInfo) 
            : base(unitOfWork, unitOfWork.IncomeGroupRepository)
        {
            this.unitOfWork = unitOfWork;
            this.exceptionHelper = exceptionHelper;
            this.requestInfo = requestInfo;
        }
    }
}
