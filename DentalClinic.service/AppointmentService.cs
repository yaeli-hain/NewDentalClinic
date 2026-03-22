using DentalClinic.Core.Repositories;
using DentalClinic.Core.Services;
using DentlClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task<List<Appointment>> GetAppointmentsAsync()
        {
            return await _appointmentRepository.GetAppointmentsAsync();
        }

        public async Task<Appointment> GetByIdAsync(int id)
        {
            return await _appointmentRepository.GetByIdAsync(id);
        }

        public Appointment Add(Appointment appointment)
        {
            return _appointmentRepository.Add(appointment);
        }

        public async Task<Appointment> UpdateAsync(int id, Appointment appointment)
        {
            return await _appointmentRepository.UpdateAsync(id, appointment);
        }

        public async Task DeleteAsync(int id)
        {
            await _appointmentRepository.DeleteAsync(id);
        }
    }
}
