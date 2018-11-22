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
    public class AppointmentService : Service<IAppointmentRepository, Appointment, AppointmentDTO, int>, IAppointmentService
    {
        private readonly ISSHRequestInfo requestInfo;
        private readonly IExceptionHelper exceptionHelper;
        private readonly ISSHUnitOfWork unitOfWork;

        public AppointmentService(ISSHUnitOfWork unitOfWork, ISSHRequestInfo requestInfo, IExceptionHelper exceptionHelper)
            : base(unitOfWork, unitOfWork.AppointmentRepository)
        {
            this.requestInfo = requestInfo;
            this.exceptionHelper = exceptionHelper;
            this.unitOfWork = unitOfWork;
        }

        public override async Task<AppointmentDTO> CreateAsync(AppointmentDTO dtoObject)
        {
            /* 1. User can select opd, doctor, particular date from calendar & slot of that doctor.
             * :Find Slot # By Going in Dr.OPD and getting ST, ET & Duration.
             * 2. Check for provided Slot# is in between Dr. no of slots 
             * 3. Check this slot also not given to other patient by Dr.OPD ID in today date
             * 3. Get ST & ET by that Slot # from Doctor OPD.
             * 
             * Two ways of Appointment: 
             * 1. Walk-in apnt.: Place him in appointment & TimeSlot.
             * 2. Registered Patient apnt.: Only Place him in TimeSlot. Switch him to enter only Dr.OPD TimeSlot.
            */

            if (dtoObject == null || dtoObject.DoctorOPDTimeSlotDto == null)
            {
                this.exceptionHelper.ThrowAPIException(string.Format(Message.ObjectRequired, "Appointment details not provided correctly"));
            }

            if (string.IsNullOrEmpty(dtoObject.PatientName) || string.IsNullOrEmpty(dtoObject.ContactNumber))
            {
                this.exceptionHelper.ThrowAPIException(string.Format(Message.ObjectRequired, "Appointment details not provided correctly"));
            }
            else if (dtoObject.DoctorOPDTimeSlotDto != null)
            {
                if (dtoObject.DoctorOPDTimeSlotDto.Count() < 1)
                {
                    this.exceptionHelper.ThrowAPIException(string.Format(Message.ObjectRequired, "Appointment details not provided correctly"));
                }
            }

            // Find Slot # By Going in Dr.OPD and getting ST, ET & Duration By Dr.OPD ID
            var docOpdEntity = await this.unitOfWork.DoctorOPDRepository.GetAsync(dtoObject.DoctorOPDId);

            if (docOpdEntity == null)
            {
                this.exceptionHelper.ThrowAPIException(string.Format(Message.NotFound, "Doctor Opd you provided not exist"));
            }

            // Check for provided Slot# is in between Dr. no of slots
            //var totalTime = docOpdEntity.EndTime - docOpdEntity.StartTime;
            //var noOfTimeSlots = ((totalTime.Hours * 60) + totalTime.Minutes) / docOpdEntity.DurationInMinutes;

            foreach (var timeSlotDto in dtoObject.DoctorOPDTimeSlotDto)
            {
                if (timeSlotDto.AppointmentDate.Date < DateTime.Now.Date || timeSlotDto.DoctorOPDId != dtoObject.DoctorOPDId)
                {
                    this.exceptionHelper.ThrowAPIException(string.Format(Message.NotFound, "Please provide data correctly"));
                }
                // Check for slot also not given to other patient in today date by Dr.OPD ID in timeSlot : Except Cancelled
                var timeSlotEntity = await this.unitOfWork.DoctorOPDTimeSlotRepository.IsPatientOnThatSlotExist(timeSlotDto.DoctorOPDId, timeSlotDto.AppointmentDate, timeSlotDto.SlotNumber);

                if (timeSlotEntity != null)
                {
                    this.exceptionHelper.ThrowAPIException(string.Format(Message.NotFound, "This slot number is already appointed to other."));
                }

                // Check for provided Slot# is in between Dr. no of slots
                if (timeSlotDto.SlotNumber < 1 && timeSlotDto.SlotNumber > docOpdEntity.NoOfTimeSlots)
                {
                    this.exceptionHelper.ThrowAPIException(string.Format(Message.NotFound, "You selected wrong time slot"));
                }

                timeSlotDto.Status = DoctorOPDTimeSlotStatus.Pending;
            }

            dtoObject.Status = AppointmentStatus.Pending;

            return await base.CreateAsync(dtoObject);
        }

        public async Task<int> DeleteAppointmentAsync(int id)
        {
            // Dr opd & its related entity of that Dr Opd ID
            var apmntEntityList = await this.Repository.GetAsync(id);

            if (apmntEntityList == null || apmntEntityList.DoctorOPDTimeSlot == null)
            {
                // Throw exception
                this.exceptionHelper.ThrowAPIException(string.Format(Message.NotFound, "Appointment or its time slots not exist"));
            }

            // If Appointment Exist: Delete All appointment SLots. 
            foreach (var e in apmntEntityList.DoctorOPDTimeSlot)
            {
                e.IsDeleted = true;
                e.LastModifiedOn = DateTime.UtcNow;
            }

            // Master Appointment modified for delete
            apmntEntityList.IsDeleted = true;
            apmntEntityList.LastModifiedOn = DateTime.UtcNow;

            this.UnitOfWork.DBContext.Set<Appointment>().Attach(apmntEntityList);

            this.UnitOfWork.DBContext.Entry(apmntEntityList).Property(x => x.IsDeleted).IsModified = true;
            this.UnitOfWork.DBContext.Entry(apmntEntityList).Property(x => x.LastModifiedOn).IsModified = true;

            return await this.UnitOfWork.SaveAsync();
        }

        public async Task<List<AppointmentDTO>> GetByStatus(AppointmentStatus status)
        {
            var result = await this.Repository.GetByStatus(status);
            return AppointmentDTO.ConvertEntityListToDTOList<AppointmentDTO>(result);
        }
    }
}
