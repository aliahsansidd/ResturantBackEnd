using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Core.Base.Abstract;

namespace SSH.Core.Entity
{
    public class Appointment : EntityBase<int>
    {
        public string PatientName { get; set; }

        public string ContactNumber { get; set; }

        public int Status { get; set; }

        public virtual IList<DoctorOPDTimeSlot> DoctorOPDTimeSlot { get; set; }
    }
}
