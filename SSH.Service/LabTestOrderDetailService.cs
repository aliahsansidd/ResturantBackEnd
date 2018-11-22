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
    public class LabTestOrderDetailService : Service<ILabTestOrderDetailRepository, LabTestOrderDetail, LabTestOrderDetailDTO, int>, ILabTestOrderDetailService
    {
        private ISSHUnitOfWork unitOfWork;
        private IExceptionHelper exceptionHelper;
        private ISSHRequestInfo requestInfo;

        public LabTestOrderDetailService(ISSHUnitOfWork unitOfWork, IExceptionHelper exceptionHelper, ISSHRequestInfo requestInfo) 
            : base(unitOfWork, unitOfWork.LabTestOrderDetailRepository)
        {
            this.unitOfWork = unitOfWork;
            this.exceptionHelper = exceptionHelper;
            this.requestInfo = requestInfo;
        }
    }
}
