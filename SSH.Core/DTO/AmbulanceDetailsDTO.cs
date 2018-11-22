using System;
using System.Threading.Tasks;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class AmbulanceDetailsDTO : DTO<AmbulanceDetails, int>
    {
        public string Name { get; set; }

        public string VehicleNo { get; set; }

        public string CenterNo { get; set; }

        public string Location { get; set; }

        public string MadadgarName { get; set; }

        public int? AccidentAndEmergencyID { get; set; }

        public override void ConvertFromEntity(AmbulanceDetails entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.VehicleNo = entity.VehicleNo;
            this.CenterNo = entity.CenterNo;
            this.Location = entity.Location;
            this.MadadgarName = entity.MadadgarName;
            this.AccidentAndEmergencyID = entity.AccidentAndEmergencyID;
        }

        public override AmbulanceDetails ConvertToEntity(AmbulanceDetails entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.VehicleNo = this.VehicleNo;
            entity.CenterNo = this.CenterNo;
            entity.Location = this.Location;
            entity.MadadgarName = this.MadadgarName;
            entity.AccidentAndEmergencyID = this.AccidentAndEmergencyID;
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastModifiedOn = DateTime.UtcNow;

            return entity;
        }    
    }
}