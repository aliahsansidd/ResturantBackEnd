using System;
using Recipe.Core.Base.Abstract;
using SSH.Common.Helper;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class PatientDTO : DTO<Patient, int>
    {
        public string DisplayId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FamilyHeadName { get; set; }

        public string CellNumber { get; set; }

        public string LandLineNumber { get; set; }

        public string EmergencyNumber { get; set; }

        public string Address { get; set; }

        public string CNIC { get; set; }

        public string City { get; set; }

        public string DOB { get; set; }

        public int? Age { get; set; }

        public string Gender { get; set; }

        public string Religion { get; set; }

        public string MaritalStatus { get; set; }

        public PatientStatus Status { get; set; }

        public string CardExpiry { get; set; }

        public string CreatedOn { get; set; }

        public override void ConvertFromEntity(Patient entity)
        {
            base.ConvertFromEntity(entity);
            this.Address = entity.Address;
            this.Age = entity.Age;
            this.CellNumber = entity.CellNumber;
            this.City = entity.City;
            this.CNIC = entity.CNIC;
            this.DOB = entity.DOB.HasValue ? entity.DOB.Value.ToString(Validations.DateFormat) : null;
            this.EmergencyNumber = entity.EmergencyNumber;
            this.Gender = entity.Gender;
            this.LandLineNumber = entity.LandLineNumber;
            this.MaritalStatus = entity.MaritalStatus;
            this.FirstName = entity.FirstName;
            this.MiddleName = entity.MiddleName;
            this.LastName = entity.LastName;
            this.FamilyHeadName = entity.FamilyHeadName;
            this.Religion = entity.Religion;
            this.Status = (PatientStatus)entity.Status;
            this.CardExpiry = entity.CardExpiry.ToString(Validations.DateFormat);
            this.DisplayId = string.Format("{0}-{1}-{2}", "mr", entity.Id.ToString(), entity.CreatedOn.ToString("yy"));
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
        }

        public override Patient ConvertToEntity(Patient entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Address = this.Address;
            entity.Age = this.Age;
            entity.CellNumber = this.CellNumber;
            entity.City = this.City;
            entity.CNIC = this.CNIC;
            entity.DOB = this.DOB.GetDate();
            entity.EmergencyNumber = this.EmergencyNumber;
            entity.Gender = this.Gender;
            entity.LandLineNumber = this.LandLineNumber;
            entity.MaritalStatus = this.MaritalStatus;
            entity.FirstName = this.FirstName;
            entity.MiddleName = this.MiddleName;
            entity.LastName = this.LastName;
            entity.FamilyHeadName = this.FamilyHeadName;
            entity.Religion = this.Religion;
            entity.Status = (int)this.Status;
            entity.CardExpiry = (DateTime)this.CardExpiry.GetDate();

            return entity;
        }
    }
}