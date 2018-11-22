using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class Death : EntityBase<int>
    {
        public Death()
        {
        }

        public string Type { get; set; }

        public string BookSrNumber { get; set; }

        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        public DateTime DeathDateTime { get; set; }

        public DateTime? AdmissionDateTime { get; set; }

        public string AdmissionNo { get; set; }

        public string ReasonOfDeath { get; set; }

        public string Occupation { get; set; }

        public string Province { get; set; }

        public string TownOrVillage { get; set; }

        public bool IsCertificatePrinted { get; set; }

        public int Status { get; set; }
    }
}
