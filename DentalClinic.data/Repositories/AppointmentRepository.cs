using DentalClinic.Core.Repositories;
using DentlClinic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DentalClinic.Data.Repositories
{
    public class AppointmentRepository : IAppointmentRepository

    {
        private readonly DataContext _context;
        public AppointmentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Appointment>> GetAppointmentsAsync()
        {
            return  await _context.Appointments.Include(a => a.Treatment).ToListAsync();
        }
        public async Task< Appointment> GetByIdAsync(int id)
        {
            return await _context.Appointments.FirstOrDefaultAsync(x => x.Id == id);
        }
        public Appointment Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            return appointment;
        }
        public async Task<Appointment> UpdateAsync(int id, Appointment appointment)
        {
            var a = await GetByIdAsync(appointment.Id);
            a.ClientId = appointment.ClientId;
            a.Client = appointment.Client;
            a.IsCompleted = appointment.IsCompleted;
            return a;
        }
        public async Task DeleteAsync(int id)
        {
            var a =await GetByIdAsync(id);
            _context.Appointments.Remove(a);
        }
        public async Task SaveAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}
