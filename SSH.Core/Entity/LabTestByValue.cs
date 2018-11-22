using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class LabTestByValue : EntityBase<int>
    {
        public LabTestByValue()
        {    
        }

        public string ResultLabel { get; set; }

        public int Priority { get; set; }

        // Is applicable for all is using for gender. If we work on only gender
        public string Gender { get; set; }

        // RANGES FOR MALE
        public int IsAgeInDayMonthYearForMale { get; set; }

        public int MaleAgeMin { get; set; }

        public int MaleAgeMax { get; set; }

        public string MaleNormalRangeMin { get; set; }

        public string MaleNormalRangeMax { get; set; }

        public string MaleAbnormalRangeMin { get; set; }

        public string MaleAbnormalRangeMax { get; set; }

        public string MaleCriticalRangeMin { get; set; }

        public string MaleCriticalRangeMax { get; set; }

        // RANGES FOR FEMALE
        public int IsAgeInDayMonthYearForFemale { get; set; }

        public int FemaleAgeMin { get; set; }

        public int FemaleAgeMax { get; set; }

        public string FemaleNormalRangeMin { get; set; }

        public string FemaleNormalRangeMax { get; set; }

        public string FemaleAbnormalRangeMin { get; set; }

        public string FemaleAbnormalRangeMax { get; set; }

        public string FemaleCriticalRangeMin { get; set; }

        public string FemaleCriticalRangeMax { get; set; }

        public int LabTestTemplateId { get; set; }

        public virtual LabTestTemplate LabTestTemplate { get; set; }

        public int LabTestingUnitId { get; set; }

        public virtual LabTestingUnit LabTestingUnit { get; set; }
    }
}
