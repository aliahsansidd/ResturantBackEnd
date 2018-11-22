using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class Birth : EntityBase<int>
    {
        public Birth()
        {
        }

        public string BookSrNumber { get; set; }

        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        public string ChildName { get; set; }

        public string ChildGender { get; set; }

        public string TypeOfDelivery { get; set; }

        public string Disability { get; set; }

        public double Weight { get; set; }

        [DataType(DataType.Time)]
        public DateTime BirthTime { get; set; }

        public string CaseConductedBy { get; set; }

        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        public bool IsCertificatePrinted { get; set; }

        public int Status { get; set; }
    }
}
