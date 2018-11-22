using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class DeathDTO : DTO<Death, int>
    {
        public string DisplayId { get; set; }

        public string Type { get; set; }

        public string BookSrNumber { get; set; }

        public int PatientId { get; set; }

        public DateTime DeathDateTime { get; set; }

        public DateTime? AdmissionDateTime { get; set; }

        public string AdmissionNo { get; set; }

        public string ReasonOfDeath { get; set; }

        public string Occupation { get; set; }

        public string Province { get; set; }

        public string TownOrVillage { get; set; }

        public bool IsCertificatePrinted { get; set; }

        public DeathStatus Status { get; set; }

        public override void ConvertFromEntity(Death entity)
        {
            base.ConvertFromEntity(entity);
            this.AdmissionNo = entity.AdmissionNo;
            this.AdmissionDateTime = entity.AdmissionDateTime;
            this.BookSrNumber = entity.BookSrNumber;
            this.Occupation = entity.Occupation;
            this.TownOrVillage = entity.TownOrVillage;
            this.Province = entity.Province;
            this.DeathDateTime = entity.DeathDateTime;
            this.DisplayId = string.Format("{0}-{1}-{2}", "DR", entity.Id.ToString(), entity.CreatedOn.ToString("yy"));
            this.IsCertificatePrinted = entity.IsCertificatePrinted;
            this.PatientId = entity.PatientId;
            this.ReasonOfDeath = entity.ReasonOfDeath;
            this.Status = (DeathStatus)entity.Status;
            this.Type = entity.Type;
        }

        public override Death ConvertToEntity(Death entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.AdmissionNo = this.AdmissionNo;
            entity.AdmissionDateTime = this.AdmissionDateTime;
            entity.Occupation = this.Occupation;
            entity.TownOrVillage = this.TownOrVillage;
            entity.Province = this.Province;
            entity.BookSrNumber = this.BookSrNumber;
            entity.DeathDateTime = this.DeathDateTime;
            entity.IsCertificatePrinted = this.IsCertificatePrinted;
            entity.PatientId = this.PatientId;
            entity.ReasonOfDeath = this.ReasonOfDeath;
            entity.Status = (int)this.Status;
            entity.Type = this.Type;

            return entity;
        }
    }
}