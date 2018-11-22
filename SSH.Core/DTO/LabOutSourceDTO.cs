using System;
using Recipe.Core.Base.Abstract;
using SSH.Common.Helper;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class LabOutSourceDTO : DTO<LabOutSource, int>
    {
        public string Name { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public override void ConvertFromEntity(LabOutSource entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Contact = entity.Contact;
            this.Email = entity.Email;
            this.Address = entity.Address;
        }

        public override LabOutSource ConvertToEntity(LabOutSource entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Contact = this.Contact;
            entity.Email = this.Email;
            entity.Address = this.Address;

            return entity;
        }
    }
}