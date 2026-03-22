using DentalClinic.Core.Repositories;
using DentalClinic.Core.Services;
using DentalClinic.Data.Repositories;
using DentlClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Service
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository _treatmentRepository;
        public TreatmentService(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }
        public Treatment Add(Treatment treatment)
        {
            return _treatmentRepository.Add(treatment);
        }

        public async Task DeleteAsync(int id)
        {
            await _treatmentRepository.DeleteAsync(id);
        }

        public async Task<Treatment> GetTreatmentByIdAsync(int id)
        {
            return await _treatmentRepository.GetTreatmentByIdAsync(id);
        }

        public async Task<List<Treatment>> GetTreatmentsAsync()
        {

            return await _treatmentRepository.GetTreatmentsAsync();
        }

        public async Task<Treatment> UpdateAsync(int id, Treatment treatment)
        {
            return await _treatmentRepository.UpdateAsync(id, treatment);
        }


    }
}
