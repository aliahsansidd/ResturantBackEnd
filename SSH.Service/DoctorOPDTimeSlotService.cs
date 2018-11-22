using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recipe.Common.Helper;
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
    public class DoctorOPDTimeSlotService : Service<IDoctorOPDTimeSlotRepository, DoctorOPDTimeSlot, DoctorOPDTimeSlotDTO, int>, IDoctorOPDTimeSlotService
    {
        private readonly ISSHRequestInfo requestInfo;
        private readonly IExceptionHelper exceptionHelper;
        private readonly ISSHUnitOfWork unitOfWork;

        public DoctorOPDTimeSlotService(
            ISSHUnitOfWork unitOfWork,
            ISSHRequestInfo requestInfo,
            IExceptionHelper exceptionHelper)
            : base(unitOfWork, unitOfWork.DoctorOPDTimeSlotRepository)
        {
            this.requestInfo = requestInfo;
            this.exceptionHelper = exceptionHelper;
            this.unitOfWork = unitOfWork;
        }

        // Only Status of that time slot will update
        public override async Task<IList<DoctorOPDTimeSlotDTO>> UpdateAsync(IList<DoctorOPDTimeSlotDTO> dtoObject)
        {
            if (dtoObject == null)
            {
                this.exceptionHelper.ThrowAPIException(string.Format(Message.ObjectRequired, "Time Slot details not provided correctly"));
            }
            else if (dtoObject != null)
            {
                if (dtoObject.Count() < 1)
                {
                    this.exceptionHelper.ThrowAPIException(string.Format(Message.ObjectRequired, "Time Slot details not provided correctly"));
                }
            }

            return await base.UpdateAsync(dtoObject);
        }

        // GET ALL APPOINTMENTS TIME SLOTS BY DOCTOR OPD ID & Provided Date
        public async Task<IList<DoctorOPDTimeSlot>> GetAppointmentTimeSlotsByDoctorOPD(DoctorOPDTimeSlotDTO dtoObject)
        {
            dtoObject.AppointmentDate = dtoObject.AppointmentDate.Date;
            var apmntTimeSlots = await this.Repository.GetAppointmentTimeSlotsByDoctorOpd(dtoObject.DoctorOPDId, dtoObject.AppointmentDate.Date);

            return apmntTimeSlots;
        }

        public async Task<List<DoctorOPDTimeSlotDTO>> GetByStatus(DoctorOPDTimeSlotStatus status)
        {
            var result = await this.Repository.GetByStatus(status);
            return DoctorOPDTimeSlotDTO.ConvertEntityListToDTOList<DoctorOPDTimeSlotDTO>(result);
        }
    }
}
