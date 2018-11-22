using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class InsuranceCompaniesDTO : DTO<InsuranceCompanies, int>
    {
        public string Name { get; set; }

        public InsuranceCompaniesStatus Status { get; set; }
        
        public override void ConvertFromEntity(InsuranceCompanies entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Status = (InsuranceCompaniesStatus)entity.Status;   
        }

        public override InsuranceCompanies ConvertToEntity(InsuranceCompanies entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Status = (int)this.Status;
            
            return entity;
        }
    }
}