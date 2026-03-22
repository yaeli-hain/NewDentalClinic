using DentlClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Core.Repositories
{
    public interface IAppointmentRepository
    {
        public Task<List<Appointment>> GetAppointmentsAsync();
        public Task<Appointment> GetByIdAsync(int id);
        public Appointment Add(Appointment appointment);
        public Task<Appointment> UpdateAsync(int id,Appointment appointment);
        public Task DeleteAsync(int id);
    }
}
