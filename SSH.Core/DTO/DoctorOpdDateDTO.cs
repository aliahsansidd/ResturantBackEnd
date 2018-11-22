using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class DoctorOpdDateDTO : DTO<DoctorOpdDate, int>
    {
        public int DoctorOPDId { get; set; }

        public int OPDId { get; set; }

        public int DoctorId { get; set; }

        public DateTime Date { get; set; }

        public bool IsSittingOnThisDate { get; set; }

        public string CreatedOn { get; set; }

        public override void ConvertFromEntity(DoctorOpdDate entity)
        {
            base.ConvertFromEntity(entity);
            this.DoctorOPDId = entity.DoctorOPDId;
            this.OPDId = entity.OPDId;
            this.DoctorId = entity.DoctorId;
            this.Date = entity.Date;
            this.IsSittingOnThisDate = entity.IsSittingOnThisDate;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
        }

        public override DoctorOpdDate ConvertToEntity(DoctorOpdDate entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.DoctorOPDId = this.DoctorOPDId;
            entity.OPDId = this.OPDId;
            entity.DoctorId = this.DoctorId;
            entity.Date = this.Date.Date;
            entity.IsSittingOnThisDate = this.IsSittingOnThisDate;
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastModifiedOn = DateTime.UtcNow;

            return entity;
        }
    }
}
