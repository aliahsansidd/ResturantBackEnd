using System;
using System.Collections.Generic;
using System.Linq;
using Recipe.Core.Base.Abstract;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class DoctorOPDDTO : DTO<DoctorOPD, int>
    {
        public int DoctorId { get; set; }

        public UserDTO DoctorUser { get; set; }

        public int OPDId { get; set; }

        public string OPDName { get; set; }

        public int DoctorCategoryId { get; set; }

        public string DoctorCategoryName { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int DurationInMinutes { get; set; }

        public double Fee { get; set; }

        public int NoOfTimeSlots { get; set; }

        public bool IsRoutineBased { get; set; }

        public string WeekAndDays { get; set; }

        public DateTime? StartDateRange { get; set; }

        public DateTime? EndDateRange { get; set; }

        public int RoomId { get; set; }

        public string RoomName { get; set; }

        // DrNotAvailable, DrAvailable, DrLeft
        public DoctorOPDStatus DrAvailability { get; set; }

        public string DrAvailabilityReason { get; set; }

        public List<DoctorOpdDateDTO> DoctorOpdDateDto { get; set; }

        public string CreatedOn { get; set; }

        public override void ConvertFromEntity(DoctorOPD entity)
        {
            base.ConvertFromEntity(entity);
            this.DoctorCategoryId = entity.DoctorCategoryId;
            this.DoctorId = entity.DoctorId;
            this.OPDId = entity.OPDId;
            this.StartTime = entity.StartTime;
            this.EndTime = entity.EndTime;
            this.DurationInMinutes = entity.DurationInMinutes;
            this.IsRoutineBased = entity.IsRoutineBased;
            this.WeekAndDays = entity.WeekAndDays;
            this.StartDateRange = entity.StartDateRange != null ? entity.StartDateRange : null;
            this.EndDateRange = entity.EndDateRange != null ? entity.EndDateRange : null;
            this.NoOfTimeSlots = entity.NoOfTimeSlots;
            this.Fee = entity.Fee;
            this.DrAvailability = (DoctorOPDStatus)entity.DrAvailability;
            this.DrAvailabilityReason = entity.DrAvailabilityReason;
            this.DoctorCategoryName = entity.DoctorCategory != null ? entity.DoctorCategory.Name : null;
            this.DoctorOpdDateDto = entity.DoctorOpdDate != null ? DoctorOpdDateDTO.ConvertEntityListToDTOList<DoctorOpdDateDTO>(entity.DoctorOpdDate) : null;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);

            if (entity.Doctor != null && entity.Doctor.ApplicationUserDoctor != null)
            {
                UserDTO user = new UserDTO();
                user.ConvertFromEntity(entity.Doctor.ApplicationUserDoctor);
                this.DoctorUser = user;
            }

            this.OPDName = entity.OPD != null ? entity.OPD.Name : null;
            this.RoomId = entity.RoomId;
            this.RoomName = entity.Room != null ? entity.Room.Name : null;
        }

        public override DoctorOPD ConvertToEntity(DoctorOPD entity)
        {
            entity = base.ConvertToEntity(entity);
            //entity.Days = this.Days;
            entity.DoctorCategoryId = this.DoctorCategoryId;
            entity.DoctorId = this.DoctorId;
            entity.OPDId = this.OPDId;
            entity.StartTime = this.StartTime;
            entity.EndTime = this.EndTime;
            entity.DurationInMinutes = this.DurationInMinutes;
            entity.NoOfTimeSlots = this.NoOfTimeSlots;
            entity.Fee = this.Fee;
            entity.IsRoutineBased = this.IsRoutineBased;
            entity.WeekAndDays = this.WeekAndDays;
            entity.StartDateRange = this.StartDateRange != null ? this.StartDateRange : null;
            entity.EndDateRange = this.EndDateRange != null ? this.EndDateRange : null;
            entity.DrAvailability = (int)this.DrAvailability;
            entity.DrAvailabilityReason = this.DrAvailabilityReason;
            entity.RoomId = this.RoomId;
            entity.DoctorOpdDate = this.DoctorOpdDateDto != null ?
                this.DoctorOpdDateDto.Count() > 0 ? DoctorOpdDateDTO.ConvertDTOListToEntity(this.DoctorOpdDateDto) : null : null;

            return entity;
        }
    }
}
