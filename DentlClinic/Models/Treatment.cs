using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DentlClinic.Models
{
    public class Treatment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime TreatmentDate { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }

}