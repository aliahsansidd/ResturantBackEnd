using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class ClientTypeDTO : DTO<ClientType, int>
    {
        public string Name { get; set; }

        public string Remarks { get; set; }

        public int ClientGroupID { get; set; }

        public ClientTypeStatus Status { get; set; }
        
        public override void ConvertFromEntity(ClientType entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Remarks = entity.Remarks;
            this.ClientGroupID = entity.ClientGroupID;
            this.Status = (ClientTypeStatus)entity.Status;   
        }

        public override ClientType ConvertToEntity(ClientType entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.ClientGroupID = this.ClientGroupID;
            entity.Name = this.Name;
            entity.Remarks = this.Remarks;
            entity.Status = (int)this.Status;
            
            return entity;
        }
    }
}