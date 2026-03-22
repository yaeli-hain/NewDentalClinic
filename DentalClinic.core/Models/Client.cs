using DentlClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DentlClinic.Models
{

    public class Client
    {
        public int id { get; set; }
        public string Identity { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<Appointment> Appointments { get; set; }

    }

}