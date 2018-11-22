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
    public class AccidentAndEmergencyService : Service<IAccidentAndEmergencyRepository, AccidentAndEmergency, AccidentAndEmergencyDTO, int>, IAccidentAndEmergencyService
    {
        private readonly ISSHRequestInfo requestInfo;
        private readonly IExceptionHelper exceptionHelper;
        private readonly ISSHUnitOfWork unitOfWork;
        private readonly IBroughterDetailsService broughterDetailsService;
        private readonly IAmbulanceDetailsService ambulanceDetailsService;

        public AccidentAndEmergencyService(
            ISSHUnitOfWork unitOfWork,
            ISSHRequestInfo requestInfo,
            IExceptionHelper exceptionHelper,
            IBroughterDetailsService broughterDetailsService,
            IAmbulanceDetailsService ambulanceDetailsService)
            : base(unitOfWork, unitOfWork.AccidentAndEmergencyRepository)
        {
            this.requestInfo = requestInfo;
            this.exceptionHelper = exceptionHelper;
            this.broughterDetailsService = broughterDetailsService;
            this.unitOfWork = unitOfWork;
            this.ambulanceDetailsService = ambulanceDetailsService;
        }

        //public override async Task<AccidentAndEmergencyDTO> CreateAsync(AccidentAndEmergencyDTO dtoObject)
        //{
        //    var result = await base.CreateAsync(dtoObject);
        //    dtoObject.BroughterDetails.AccidentAndEmergencyID = result.Id;
        //    dtoObject.AmbulanceDetails.AccidentAndEmergencyID = result.Id;
        //    var broughterDetails = await this.broughterDetailsService.CreateAsync(dtoObject.BroughterDetails);
        //    var ambulanceDetails = await this.ambulanceDetailsService.CreateAsync(dtoObject.AmbulanceDetails);
        //    return result;
        //}
        public override async Task<AccidentAndEmergencyDTO> CreateAsync(AccidentAndEmergencyDTO dtoObject)
        {
            return await base.CreateAsync(dtoObject);
        }

        //public override async Task<AccidentAndEmergencyDTO> UpdateAsync(AccidentAndEmergencyDTO dtoObject)
        //{
        //    var result = await base.UpdateAsync(dtoObject);
        //    var broughterDetails = await this.broughterDetailsService.UpdateAsync(dtoObject.BroughterDetails);
        //    var ambulanceDetails = await this.ambulanceDetailsService.UpdateAsync(dtoObject.AmbulanceDetails);
        //    return result;
        //}
    }
}
