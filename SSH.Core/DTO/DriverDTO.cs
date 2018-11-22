using System;
using System.Threading.Tasks;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class DriverDTO : DTO<Driver, int>
    {
        public string Name { get; set; }

        public string Picture { get; set; }

        public string Cell { get; set; }

        public string Address { get; set; }

        public string CNIC { get; set; }

        public string LicenseNo { get; set; }

        public CommonActiveStatus Status { get; set; }

        public override void ConvertFromEntity(Driver entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Picture = entity.Picture;
            this.Cell = entity.Cell;
            this.Address = entity.Address;
            this.CNIC = entity.CNIC;
            this.LicenseNo = entity.LicenseNo;
  
            this.Status = (CommonActiveStatus)entity.Status;
        }

        public override Driver ConvertToEntity(Driver entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Picture = this.Picture;
            entity.Cell = this.Cell;
            entity.Address = this.Address;
            entity.CNIC = this.CNIC;
            entity.LicenseNo = this.LicenseNo;
            entity.Status = (int)this.Status;
            return entity;
        }    
    }
}