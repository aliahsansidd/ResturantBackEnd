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
    public class RateSheetService : Service<IRateSheetRepository, RateSheet, RateSheetDTO, int>, IRateSheetService
    {
        private ISSHRequestInfo requestInfo;
        private IExceptionHelper exceptionHelper;
        private ISSHUnitOfWork unitOfWork;

        public RateSheetService(
            ISSHUnitOfWork unitOfWork,
            ISSHRequestInfo requestInfo,
            IExceptionHelper exceptionHelper)
            : base(unitOfWork, unitOfWork.RateSheetRepository)
        {
            this.requestInfo = requestInfo;
            this.exceptionHelper = exceptionHelper;
            this.unitOfWork = unitOfWork;
        }

        public override async Task<RateSheetDTO> CreateAsync(RateSheetDTO dtoObject)
        {
            if ((dtoObject.Increment != 0 && dtoObject.Discount == 0) || (dtoObject.Increment == 0 && dtoObject.Discount != 0))
                {
                return await base.CreateAsync(dtoObject);
            }
            else
            {
                dtoObject = null;
                return dtoObject;
            }
        }
    }
}
