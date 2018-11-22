using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class BirthDTO : DTO<Birth, int>
    {
        public string DisplayId { get; set; }

        public string BookSrNumber { get; set; }

        public int PatientId { get; set; }

        public string ChildName { get; set; }

        public string ChildGender { get; set; }

        public string TypeOfDelivery { get; set; }

        public string Disability { get; set; }

        public double Weight { get; set; }

        public DateTime BirthTime { get; set; }

        public string CaseConductedBy { get; set; }

        public int DoctorId { get; set; }

        public bool IsCertificatePrinted { get; set; }

        public BirthStatus Status { get; set; }

        public override void ConvertFromEntity(Birth entity)
        {
            base.ConvertFromEntity(entity);
            this.BirthTime = entity.BirthTime;
            this.BookSrNumber = entity.BookSrNumber;
            this.CaseConductedBy = entity.CaseConductedBy;
            this.ChildGender = entity.ChildGender;
            this.ChildName = entity.ChildName;
            this.Disability = entity.Disability;
            this.DoctorId = entity.DoctorId;
            this.DisplayId = string.Format("{0}-{1}-{2}", "BR", entity.Id.ToString(), entity.CreatedOn.ToString("yy"));
            this.IsCertificatePrinted = entity.IsCertificatePrinted;
            this.PatientId = entity.PatientId;
            this.Status = (BirthStatus)entity.Status;
            this.TypeOfDelivery = entity.TypeOfDelivery;
            this.Weight = entity.Weight;
        }

        public override Birth ConvertToEntity(Birth entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.BirthTime = this.BirthTime;
            entity.BookSrNumber = this.BookSrNumber;
            entity.CaseConductedBy = this.CaseConductedBy;
            entity.ChildGender = this.ChildGender;
            entity.ChildName = this.ChildName;
            entity.Disability = this.Disability;
            entity.DoctorId = this.DoctorId;
            entity.IsCertificatePrinted = this.IsCertificatePrinted;
            entity.PatientId = this.PatientId;
            entity.Status = (int)this.Status;
            entity.TypeOfDelivery = this.TypeOfDelivery;
            entity.Weight = this.Weight;

            return entity;
        }
    }
}