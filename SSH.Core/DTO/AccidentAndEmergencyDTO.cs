using System;
using System.Collections.Generic;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class AccidentAndEmergencyDTO : DTO<AccidentAndEmergency, int>
    {
        public int? PatientID { get; set; }

        public string MrNo { get; set; }

        public string MlNo { get; set; }

        public string ErNo { get; set; }

        public CommonActiveStatus BroughtDeath { get; set; }

        public string Guardian { get; set; }

        public string Gender { get; set; }

        public string Complaint { get; set; }

        public string Address { get; set; }

        public string CNIC { get; set; }

        public string Phone { get; set; }

        public string PatientName { get; set; }

        public int? CatastrophicID { get; set; }

        public int? Age { get; set; }

        public AccidentAndEmergencyStatus Status { get; set; }

        public IList<BroughterDetailsDTO> BroughterDetails { get; set; }

        public IList<AmbulanceDetailsDTO> AmbulanceDetails { get; set; }

        public override void ConvertFromEntity(AccidentAndEmergency entity)
        {
            base.ConvertFromEntity(entity);
            this.BroughterDetails = entity.BroughterDetails != null ? BroughterDetailsDTO.ConvertEntityListToDTOList<BroughterDetailsDTO>(entity.BroughterDetails) : null;
            this.AmbulanceDetails = entity.AmbulanceDetails != null ? AmbulanceDetailsDTO.ConvertEntityListToDTOList<AmbulanceDetailsDTO>(entity.AmbulanceDetails) : null;
            this.BroughtDeath = (CommonActiveStatus)entity.BroughtDeath;
            this.MlNo = entity.MlNo;
            this.PatientName = entity.PatientName;
            this.Guardian = entity.Guardian;
            this.Gender = entity.Gender;
            this.Complaint = entity.Complaint;
            this.Address = entity.Address;
            this.CNIC = entity.CNIC;
            this.Phone = entity.Phone;
            this.Address = entity.Address;
            this.CatastrophicID = entity.CatastrophicID.HasValue ? entity.CatastrophicID : null;
            this.Age = entity.Age.HasValue ? entity.Age : null;
            this.MrNo = entity.PatientID.HasValue ? string.Format("{0}:{1}-{2}", "Mr", entity.PatientID, DateTime.UtcNow.ToString("yy")) : null;
            this.ErNo = string.Format("{0}:{1}-{2}", "Mr", entity.Id, DateTime.UtcNow.ToString("yy"));
            this.Status = (AccidentAndEmergencyStatus)entity.Status;
        }

        public override AccidentAndEmergency ConvertToEntity(AccidentAndEmergency entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.BroughterDetails = this.BroughterDetails != null ? BroughterDetailsDTO.ConvertDTOListToEntity(this.BroughterDetails) : null;
            entity.AmbulanceDetails = this.AmbulanceDetails != null ? AmbulanceDetailsDTO.ConvertDTOListToEntity(this.AmbulanceDetails) : null;
            entity.BroughtDeath = (int)this.BroughtDeath;
            entity.MlNo = this.MlNo;
            entity.Guardian = this.Guardian;
            entity.Gender = this.Gender;
            entity.Complaint = this.Complaint;
            entity.Address = this.Address;
            entity.CNIC = this.CNIC;
            entity.Phone = this.Phone;
            entity.PatientName = this.PatientName;
            entity.Address = this.Address;
            entity.CatastrophicID = this.CatastrophicID.HasValue ? entity.CatastrophicID : null;
            entity.Age = this.Age.HasValue ? entity.Age : null;
            entity.Status = (int)this.Status;
            //entity.PatientID = this.PatientID.HasValue ? this.PatientID : null;

            return entity;
        }
    }
}