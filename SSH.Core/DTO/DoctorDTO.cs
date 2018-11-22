using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class DoctorDTO : DTO<Doctor, int>
    {
        public string ApplicationUserDoctorId { get; set; }
        
        public int DoctorCategoryId { get; set; }
        
        public string Contact1 { get; set; }

        public string Contact2 { get; set; }

        public DoctorStatus Status { get; set; }

        public string CreatedOn { get; set; }

        public override void ConvertFromEntity(Doctor entity)
        {
            base.ConvertFromEntity(entity);
            this.ApplicationUserDoctorId = entity.ApplicationUserDoctorId;
            this.Contact1 = entity.Contact1;
            this.Contact2 = entity.Contact2;
            this.DoctorCategoryId = entity.DoctorCategoryId;
            this.Status = (DoctorStatus)entity.Status;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
        }

        public override Doctor ConvertToEntity(Doctor entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.ApplicationUserDoctorId = this.ApplicationUserDoctorId;
            entity.Contact1 = this.Contact1;
            entity.Contact2 = this.Contact2;
            entity.DoctorCategoryId = this.DoctorCategoryId;
            entity.Status = (int)this.Status;

            return entity;
        }
    }
}