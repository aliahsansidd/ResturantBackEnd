using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class CPTCategoryDTO : DTO<CPTCategory, int>
    {
        public string Name { get; set; }

        public CommonActiveStatus Status { get; set; }
        
        public override void ConvertFromEntity(CPTCategory entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Status = (CommonActiveStatus)entity.Status;   
        }

        public override CPTCategory ConvertToEntity(CPTCategory entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Status = (int)this.Status;
            
            return entity;
        }
    }
}