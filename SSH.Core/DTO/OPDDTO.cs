using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class OPDDTO : DTO<OPD, int>
    {
        public string Name { get; set; }
        
        public bool IsVital { get; set; }

        public string Description { get; set; }

        public override void ConvertFromEntity(OPD entity)
        {
            base.ConvertFromEntity(entity);
            this.Description = entity.Description;
            this.IsVital = entity.IsVital;
            this.Name = entity.Name;
        }

        public override OPD ConvertToEntity(OPD entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Description = this.Description;
            entity.IsVital = this.IsVital;
            entity.Name = this.Name;

            return entity;
        }
    }
}