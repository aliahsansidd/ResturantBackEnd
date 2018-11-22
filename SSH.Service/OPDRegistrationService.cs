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
    public class OPDRegistrationService : Service<IOPDRegistrationRepository, OPDRegistration, OPDRegistrationDTO, int>, IOPDRegistrationService
    {
        private readonly ISSHRequestInfo requestInfo;
        private readonly IExceptionHelper exceptionHelper;
        private readonly ISSHUnitOfWork unitOfWork;

        public OPDRegistrationService(
            ISSHUnitOfWork unitOfWork,
            ISSHRequestInfo requestInfo,
            IExceptionHelper exceptionHelper)
            : base(unitOfWork, unitOfWork.OPDRegistrationRepository)
        {
            this.requestInfo = requestInfo;
            this.exceptionHelper = exceptionHelper;
            this.unitOfWork = unitOfWork;
        }

        public override async Task<OPDRegistrationDTO> CreateAsync(OPDRegistrationDTO dtoObject)
        {
            // Why Status of TimeSlot & OPD is SAME? Need to change here.
            dtoObject.Status = DoctorOPDTimeSlotStatus.Pending;
            //dtoObject.Status = DoctorOPDTimeSlotStatus.InComplete;
            return await base.CreateAsync(dtoObject);
        }

        public async Task<List<OPDRegistrationDTO>> GetByStatus(DoctorOPDTimeSlotStatus status)
        {
            var result = await this.Repository.GetByStatus(status);
            return OPDRegistrationDTO.ConvertEntityListToDTOList<OPDRegistrationDTO>(result);
        }
    }
}
