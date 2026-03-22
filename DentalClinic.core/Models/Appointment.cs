using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DentlClinic.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public bool IsCompleted { get; set; }
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
       
    }

}