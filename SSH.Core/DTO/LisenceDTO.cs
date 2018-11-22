using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class LisenceDTO : DTO<Lisence, int>
    {
        public int OrganizationID { get; set; }

        public string LicenceNumber { get; set; }

        public int? TempPincode { get; set; }

        public int? NoOfUsers { get; set; }

        public int? ValidityPeriod { get; set; }

        public DateTime? ExpirtDate { get; set; }

        public int? GracePeriod { get; set; }

        public CommonActiveStatus Status { get; set; }

        public override void ConvertFromEntity(Lisence entity)
        {
            base.ConvertFromEntity(entity);
            this.LicenceNumber = entity.LicenceNumber;
            this.TempPincode = entity.TempPincode;
            this.NoOfUsers = entity.NoOfUsers;
            this.ValidityPeriod = entity.ValidityPeriod;
            this.ExpirtDate = entity.ExpirtDate;
            this.GracePeriod = entity.GracePeriod;
            this.OrganizationID = entity.OrganizationID;
            this.Status = (CommonActiveStatus)entity.Status;
        }

        public override Lisence ConvertToEntity(Lisence entity)
        {
            entity = base.ConvertToEntity(entity);
            //this.Status = CommonActiveStatus.InActive;
            entity.NoOfUsers = this.NoOfUsers;
            entity.ValidityPeriod = this.ValidityPeriod;
            entity.OrganizationID = this.OrganizationID;
            entity.Status = (int)this.Status;

            return entity;
        }
    }
}