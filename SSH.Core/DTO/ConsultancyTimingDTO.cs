using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class ConsultancyTimingDTO : DTO<ConsultancyTiming, int>
    {
        public string Name { get; set; }
        
        public DateTime StartTime { get; set; }
        
        public DateTime EndTime { get; set; }

        public string Days { get; set; }

        public ConsultancyTimingStatus Status { get; set; }

        public string CreatedOn { get; set; }

        public override void ConvertFromEntity(ConsultancyTiming entity)
        {
            base.ConvertFromEntity(entity);
            this.Days = entity.Days;
            this.EndTime = entity.EndTime;
            this.Name = entity.Name;
            this.StartTime = entity.StartTime;
            this.Status = (ConsultancyTimingStatus)entity.Status;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
        }

        public override ConsultancyTiming ConvertToEntity(ConsultancyTiming entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Days = this.Days;
            entity.EndTime = this.EndTime;
            entity.Name = this.Name;
            entity.StartTime = this.StartTime;
            entity.Status = (int)this.Status;

            return entity;
        }
    }
}