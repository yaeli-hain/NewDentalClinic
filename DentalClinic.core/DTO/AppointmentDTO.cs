using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Core.DTO
{
    public class AppointmentDTO
    {
        public DateTime AppointmentDate { get; set; }
        public int TreatmentId { get; set; }
    }
}
