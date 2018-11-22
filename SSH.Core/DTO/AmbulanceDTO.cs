using System;
using System.Threading.Tasks;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class AmbulanceDTO : DTO<Ambulance, int>
    {
        public string BrandName { get; set; }

        public string Category { get; set; }

        public string Version { get; set; }

        public string CenterName { get; set; }

        public string ChassisNo { get; set; }

        public string Location { get; set; }

        public string EngineNo { get; set; }

        public DateTime CreatedOn { get; set; }

        public CommonActiveStatus Status { get; set; }

        public override void ConvertFromEntity(Ambulance entity)
        {
            base.ConvertFromEntity(entity);
            this.Location = entity.Location;
            this.BrandName = entity.BrandName;
            this.Category = entity.Category;
            this.Version = entity.Version;
            this.CenterName = entity.CenterName;
            this.ChassisNo = entity.ChassisNo;
            this.EngineNo = entity.EngineNo;
            this.CreatedOn = entity.CreatedOn;
            this.Status = (CommonActiveStatus)entity.Status;
        }

        public override Ambulance ConvertToEntity(Ambulance entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.BrandName = this.BrandName;
            entity.Category = this.Category;
            entity.Version = this.Version;
            entity.CenterName = this.CenterName;
            entity.ChassisNo = this.ChassisNo;
            entity.EngineNo = this.EngineNo;
            entity.Location = this.Location;
            entity.Status = (int)this.Status;
            return entity;
        }    
    }
}