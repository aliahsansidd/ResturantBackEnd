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
    public class DoctorOPDService : Service<IDoctorOPDRepository, DoctorOPD, DoctorOPDDTO, int>, IDoctorOPDService
    {
        private readonly ISSHRequestInfo requestInfo;
        private readonly IExceptionHelper exceptionHelper;
        private readonly ISSHUnitOfWork unitOfWork;

        public DoctorOPDService(
            ISSHUnitOfWork unitOfWork,
            ISSHRequestInfo requestInfo,
            IExceptionHelper exceptionHelper)
            : base(unitOfWork, unitOfWork.DoctorOPDRepository)
        {
            this.requestInfo = requestInfo;
            this.exceptionHelper = exceptionHelper;
            this.unitOfWork = unitOfWork;
        }

        public async override Task<DoctorOPDDTO> CreateAsync(DoctorOPDDTO dtoObject)
        {
            /* 1. Check for if Dr. OPD is Routine based OR Fixed based.
             * 2. If Routine Based : "IsRoutineBased = true", week & days=value, SDateRange-EDateRange=value.
             * 3. If Fixed Based : "IsRoutineBased = false", week & days=null, SDateRange-EDateRange=null.
             * 4. Create in Dr. OPD & OPD Dates.
             */

            if (dtoObject == null || dtoObject.DoctorOpdDateDto == null || dtoObject.StartTime >= dtoObject.EndTime ||
                (dtoObject.IsRoutineBased == true && (string.IsNullOrEmpty(dtoObject.WeekAndDays) || dtoObject.StartDateRange == null || dtoObject.EndDateRange == null)) ||
                (dtoObject.IsRoutineBased == false && (!string.IsNullOrEmpty(dtoObject.WeekAndDays) || dtoObject.StartDateRange != null || dtoObject.EndDateRange != null)) ||
                (dtoObject.StartDateRange >= dtoObject.EndDateRange))
            {
                // Don't work on these conditions.
                this.exceptionHelper.ThrowAPIException(string.Format(Message.NotFound, "Doctor Opd details not provided correctly"));
            }
            else if ((dtoObject.IsRoutineBased == true && !string.IsNullOrEmpty(dtoObject.WeekAndDays) && dtoObject.StartDateRange != null && dtoObject.EndDateRange != null) ||
                (dtoObject.IsRoutineBased == false && string.IsNullOrEmpty(dtoObject.WeekAndDays) && dtoObject.StartDateRange == null && dtoObject.EndDateRange == null))
            {
                var totalTime = dtoObject.EndTime - dtoObject.StartTime;
                dtoObject.NoOfTimeSlots = ((totalTime.Hours * 60) + totalTime.Minutes) / dtoObject.DurationInMinutes;

                return await base.CreateAsync(dtoObject);
            }
            else
            {
                this.exceptionHelper.ThrowAPIException(string.Format(Message.NotFound, "Doctor Opd details not provided correctly"));
            }

            return null;
        }

        public async override Task<DoctorOPDDTO> UpdateAsync(DoctorOPDDTO dtoObject)
        {
            /* 1. If Doctor OPD is removed : Then it will not shown in appointment.
             * 2. Active/InActive to Dr.Availability (Reason).
             */
            if (dtoObject == null)
            {
                this.exceptionHelper.ThrowAPIException(string.Format(Message.ObjectRequired, "Please provide correct details"));
            }
            else if (dtoObject.DrAvailability == DoctorOPDStatus.DrLeft)
            {
                // Dr. will left when he is deleted.
                this.exceptionHelper.ThrowAPIException(string.Format(Message.ObjectRequired, "Please provide correct details"));
            }

            var entity = await this.Repository.GetAsync(dtoObject.Id);

            if (entity == null)
            {
                this.exceptionHelper.ThrowAPIException(string.Format(Message.ObjectRequired, "Please create Doctor OPD"));
            }

            entity.DrAvailability = (int)dtoObject.DrAvailability;
            entity.DrAvailabilityReason = dtoObject.DrAvailabilityReason;
            entity.LastModifiedOn = DateTime.UtcNow;

            this.UnitOfWork.DBContext.Set<DoctorOPD>().Attach(entity);

            this.UnitOfWork.DBContext.Entry(entity).Property(x => x.DrAvailability).IsModified = true;
            this.UnitOfWork.DBContext.Entry(entity).Property(x => x.DrAvailabilityReason).IsModified = true;
            this.UnitOfWork.DBContext.Entry(entity).Property(x => x.LastModifiedOn).IsModified = true;

            await this.UnitOfWork.SaveAsync();

            return dtoObject;
        }

        public async Task<int> DeleteDoctorOpdAsync(DoctorOpdDeleteDTO dtoObject)
        {
            /* 1. Dr. Delete means he will stop taking further OPDs. Untill now he had taken appointments that are (complete or advanced booked - incomplete) will be there.
             * 2. Get Max date by Dr.Opd id from Appointment (dr opd time slot). So that we can Delete the further dates of that Dr. So that he will not shown in appointments.
             *    and make status:Dr.Availability "Left" in Dr.OPD.
             * 3. Is Delete Status of 
             */

            // Dr opd & its related entity of that Dr Opd ID
            var doctorOpdEntityList = await this.Repository.GetAsync(dtoObject.Id);

            if (doctorOpdEntityList == null || dtoObject.Id < 1)
            {
                // Throw exception
                this.exceptionHelper.ThrowAPIException(string.Format(Message.NotFound, "Provided doctor OPD not exist"));
            }

            // Getting Max Date from Appointment (Dr. OPD TIME SLOT) By Dr.OPD ID
            var timeSlotEntity = await this.unitOfWork.DoctorOPDTimeSlotRepository.GetRecordOfMaxDateByDoctorOpd(dtoObject.Id);

            if (timeSlotEntity == null)
            {
                // If timeSlotEntity = null : Delete All Dates from Dr OPD Dates 
                foreach (var e in doctorOpdEntityList.DoctorOpdDate)
                {
                    e.IsDeleted = true;
                    e.LastModifiedOn = DateTime.UtcNow;
                }
            }
            else
            {
                // If timeSlotEntity not Nulll : Delete only Dates starting from next date of Max appointment date.
                DateTime maxDateOfAppointment = timeSlotEntity.AppointmentDate.Date;
                foreach (var e in doctorOpdEntityList.DoctorOpdDate)
                {
                    if (e.Date.Date > maxDateOfAppointment)
                    {
                        e.IsDeleted = true;
                        e.LastModifiedOn = DateTime.UtcNow;
                    }
                }
            }

            // Master Dr Opd Entity modified for delete
            doctorOpdEntityList.DrAvailability = (int)DoctorOPDStatus.DrLeft;
            doctorOpdEntityList.DrAvailabilityReason = dtoObject.Reason;  // Reason to delete
            doctorOpdEntityList.IsDeleted = true;
            doctorOpdEntityList.LastModifiedOn = DateTime.UtcNow;

            this.UnitOfWork.DBContext.Set<DoctorOPD>().Attach(doctorOpdEntityList);

            this.UnitOfWork.DBContext.Entry(doctorOpdEntityList).Property(x => x.DrAvailability).IsModified = true;
            this.UnitOfWork.DBContext.Entry(doctorOpdEntityList).Property(x => x.DrAvailabilityReason).IsModified = true;
            this.UnitOfWork.DBContext.Entry(doctorOpdEntityList).Property(x => x.IsDeleted).IsModified = true;
            this.UnitOfWork.DBContext.Entry(doctorOpdEntityList).Property(x => x.LastModifiedOn).IsModified = true;

            return await this.UnitOfWork.SaveAsync();
        }
    }
}
