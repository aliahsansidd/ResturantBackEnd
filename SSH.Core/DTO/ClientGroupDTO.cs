using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class ClientGroupDTO : DTO<ClientGroup, int>
    {
        public string Name { get; set; }

        public string Remarks { get; set; }

        public ClientGroupStatus Status { get; set; }
        
        public override void ConvertFromEntity(ClientGroup entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Remarks = entity.Remarks;
            this.Status = (ClientGroupStatus)entity.Status;   
        }

        public override ClientGroup ConvertToEntity(ClientGroup entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Remarks = this.Remarks;
            entity.Status = (int)this.Status;
            
            return entity;
        }
    }
}