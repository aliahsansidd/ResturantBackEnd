using System;
using System.Threading.Tasks;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class BroughterDetailsDTO : DTO<BroughterDetails, int>
    {
        public string Name { get; set; }

        public string CNIC { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public int? AccidentAndEmergencyID { get; set; }

        public ModeOfArrivalStatus? ModeOfArrival { get; set; }
        
        public override void ConvertFromEntity(BroughterDetails entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.CNIC = entity.CNIC;
            this.Phone = entity.Phone;
            this.Address = entity.Address;
            this.AccidentAndEmergencyID = entity.AccidentAndEmergencyID;
            this.ModeOfArrival = entity.ModeOfArrival.HasValue ? (ModeOfArrivalStatus)entity.ModeOfArrival.Value : (ModeOfArrivalStatus?)null; 
        }

        public override BroughterDetails ConvertToEntity(BroughterDetails entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.CNIC = this.CNIC;
            entity.Phone = this.Phone;
            entity.Address = this.Address;
            entity.AccidentAndEmergencyID = this.AccidentAndEmergencyID;
            entity.ModeOfArrival = (this.ModeOfArrival != null) ? (int)this.ModeOfArrival : (int?)null;
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastModifiedOn = DateTime.UtcNow;

            return entity;
        }
    }
}