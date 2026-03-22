using DentlClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Core.Services
{
    public interface ITreatmentService
    {
        public Task<List<Treatment>> GetTreatmentsAsync();
        public Task<Treatment> GetTreatmentByIdAsync(int id);
        public Treatment Add(Treatment treatment);
        public Task<Treatment> UpdateAsync(int id, Treatment treatment);
        public Task DeleteAsync(int id);
    }
}
