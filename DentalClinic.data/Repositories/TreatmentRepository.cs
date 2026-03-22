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
    public class TreatmentRepository : ITreatmentRepository
    {
        private readonly DataContext _context;

        public TreatmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Treatment>> GetTreatmentsAsync()
        {
            return await _context.Treatments.Include(r => r.Appointment).ToListAsync(); ;
        }

        public async Task<Treatment> GetTreatmentByIdAsync(int id)
        {
            return await _context.Treatments.FirstOrDefaultAsync(a => a.Id == id);
        }

        public Treatment Add(Treatment Treatment)
        {
            _context.Treatments.Add(Treatment);
            return Treatment;
        }

        public async Task<Treatment> UpdateAsync(int id, Treatment Treatment)
        {
            var a = await GetTreatmentByIdAsync(Treatment.Id);
            a.Id = Treatment.Id;
            a.Description = Treatment.Description;

            return a;
        }

        public async Task DeleteAsync(int id)
        {
            var a =await GetTreatmentByIdAsync(id);
             _context.Treatments.Remove(a);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
