using System;
using Recipe.Core.Base.Abstract;
using SSH.Common.Helper;
using SSH.Core.Constant;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class LabTestByValueDTO : DTO<LabTestByValue, int>
    {
        public string ResultLabel { get; set; }

        public int Priority { get; set; }

        public string Gender { get; set; }

        // RANGES FOR MALE
        public AgeInStatus IsAgeInDayMonthYearForMale { get; set; }

        public int MaleAgeMin { get; set; }

        public int MaleAgeMax { get; set; }

        public string MaleNormalRangeMin { get; set; }

        public string MaleNormalRangeMax { get; set; }

        public string MaleAbnormalRangeMin { get; set; }

        public string MaleAbnormalRangeMax { get; set; }

        public string MaleCriticalRangeMin { get; set; }

        public string MaleCriticalRangeMax { get; set; }

        // RANGES FOR FEMALE
        public AgeInStatus IsAgeInDayMonthYearForFemale { get; set; }

        public int FemaleAgeMin { get; set; }

        public int FemaleAgeMax { get; set; }

        public string FemaleNormalRangeMin { get; set; }

        public string FemaleNormalRangeMax { get; set; }

        public string FemaleAbnormalRangeMin { get; set; }

        public string FemaleAbnormalRangeMax { get; set; }

        public string FemaleCriticalRangeMin { get; set; }

        public string FemaleCriticalRangeMax { get; set; }

        public string CreatedOn { get; set; }

        public int LabTestTemplateId { get; set; }

        public int LabTestingUnitId { get; set; }

        public override void ConvertFromEntity(LabTestByValue entity)
        {
            base.ConvertFromEntity(entity);
            this.ResultLabel = entity.ResultLabel;
            this.Priority = entity.Priority;
            this.Gender = entity.Gender;
            this.IsAgeInDayMonthYearForMale = (AgeInStatus)entity.IsAgeInDayMonthYearForMale;
            this.MaleAgeMin = entity.MaleAgeMin;
            this.MaleAgeMax = entity.MaleAgeMax;
            this.MaleNormalRangeMin = entity.MaleNormalRangeMin;
            this.MaleNormalRangeMax = entity.MaleNormalRangeMax;
            this.MaleAbnormalRangeMin = entity.MaleAbnormalRangeMin;
            this.MaleAbnormalRangeMax = entity.MaleAbnormalRangeMax;
            this.MaleCriticalRangeMin = entity.MaleCriticalRangeMin;
            this.MaleCriticalRangeMax = entity.MaleCriticalRangeMax;
            this.IsAgeInDayMonthYearForFemale = (AgeInStatus)entity.IsAgeInDayMonthYearForFemale;
            this.FemaleAgeMin = entity.FemaleAgeMin;
            this.FemaleAgeMax = entity.FemaleAgeMax;
            this.FemaleNormalRangeMin = entity.FemaleNormalRangeMin;
            this.FemaleNormalRangeMax = entity.FemaleNormalRangeMax;
            this.FemaleAbnormalRangeMin = entity.FemaleAbnormalRangeMin;
            this.FemaleAbnormalRangeMax = entity.FemaleAbnormalRangeMax;
            this.FemaleCriticalRangeMin = entity.FemaleCriticalRangeMin;
            this.FemaleCriticalRangeMax = entity.FemaleCriticalRangeMax;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
            this.LabTestTemplateId = entity.LabTestTemplateId;
            this.LabTestingUnitId = entity.LabTestingUnitId;
        }

        public override LabTestByValue ConvertToEntity(LabTestByValue entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.ResultLabel = this.ResultLabel;
            entity.Priority = this.Priority;
            entity.Gender = this.Gender;
            entity.IsAgeInDayMonthYearForMale = (int)this.IsAgeInDayMonthYearForMale;
            entity.MaleAgeMin = this.MaleAgeMin;
            entity.MaleAgeMax = this.MaleAgeMax;
            entity.MaleNormalRangeMin = this.MaleNormalRangeMin;
            entity.MaleNormalRangeMax = this.MaleNormalRangeMax;
            entity.MaleAbnormalRangeMin = this.MaleAbnormalRangeMin;
            entity.MaleAbnormalRangeMax = this.MaleAbnormalRangeMax;
            entity.MaleCriticalRangeMin = this.MaleCriticalRangeMin;
            entity.MaleCriticalRangeMax = this.MaleCriticalRangeMax;
            entity.IsAgeInDayMonthYearForFemale = (int)this.IsAgeInDayMonthYearForFemale;
            entity.FemaleAgeMin = this.FemaleAgeMin;
            entity.FemaleAgeMax = this.FemaleAgeMax;
            entity.FemaleNormalRangeMin = this.FemaleNormalRangeMin;
            entity.FemaleNormalRangeMax = this.FemaleNormalRangeMax;
            entity.FemaleAbnormalRangeMin = this.FemaleAbnormalRangeMin;
            entity.FemaleAbnormalRangeMax = this.FemaleAbnormalRangeMax;
            entity.FemaleCriticalRangeMin = this.FemaleCriticalRangeMin;
            entity.FemaleCriticalRangeMax = this.FemaleCriticalRangeMax;
            entity.LabTestTemplateId = this.LabTestTemplateId;
            entity.LabTestingUnitId = this.LabTestingUnitId;
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastModifiedOn = DateTime.UtcNow;

            return entity;
        }
    }
}