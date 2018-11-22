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
    public class PatientService : Service<IPatientRepository, Patient, PatientDTO, int>, IPatientService
    {
        private ISSHRequestInfo requestInfo;
        private IExceptionHelper exceptionHelper;
        private ISSHUnitOfWork unitOfWork;

        public PatientService(
            ISSHUnitOfWork unitOfWork,
            ISSHRequestInfo requestInfo,
            IExceptionHelper exceptionHelper)
            : base(unitOfWork, unitOfWork.PatientRepository)
        {
            this.requestInfo = requestInfo;
            this.exceptionHelper = exceptionHelper;
            this.unitOfWork = unitOfWork;
        }

        public override async Task<PatientDTO> CreateAsync(PatientDTO dtoObject)
        {
            var cardExpiryInYears = await this.unitOfWork.LOVRepository.GetValueByGroupAndKey(LOVGroup.Patient.ToString(), "CardExpiryInYears");
            int year = string.IsNullOrEmpty(cardExpiryInYears) ? 0 : int.Parse(cardExpiryInYears);

            dtoObject.CardExpiry = DateTime.UtcNow.AddYears(year).ToString();
            return await base.CreateAsync(dtoObject);
        }
    }
}
