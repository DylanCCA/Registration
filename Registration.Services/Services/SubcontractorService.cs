using Registration.Core.Models;
using Registration.Data.Repositories.Interfaces;
using Registration.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Services.Services
{
    public class SubcontractorService : ISubcontractorService
    {
        private readonly ISubcontractorRepository _subcontractorRepository;

        public SubcontractorService(ISubcontractorRepository subcontractorRepository)
        {
            _subcontractorRepository = subcontractorRepository;
        }

        public async Task<IEnumerable<Subcontractor>> GetAllSubcontractorsAsync()
        {
            return await _subcontractorRepository.GetAllAsync();
        }

        public async Task<Subcontractor> GetSubcontractorByIdAsync(int id)
        {
            return await _subcontractorRepository.GetWithDetailsAsync(id);
        }

        public async Task<Subcontractor> CreateSubcontractorAsync(Subcontractor subcontractor)
        {
            subcontractor.CreatedDate = DateTime.UtcNow;
            subcontractor.LastModified = DateTime.UtcNow;
            subcontractor.VerificationStatus = "Pending";
            
            await _subcontractorRepository.AddAsync(subcontractor);
            await _subcontractorRepository.SaveChangesAsync();
            
            return subcontractor;
        }

        public async Task UpdateSubcontractorAsync(Subcontractor subcontractor)
        {
            subcontractor.LastModified = DateTime.UtcNow;
            
            await _subcontractorRepository.UpdateAsync(subcontractor);
            await _subcontractorRepository.SaveChangesAsync();
        }

        public async Task DeleteSubcontractorAsync(int id)
        {
            var subcontractor = await _subcontractorRepository.GetByIdAsync(id);
            if (subcontractor != null)
            {
                await _subcontractorRepository.DeleteAsync(subcontractor);
                await _subcontractorRepository.SaveChangesAsync();
            }
        }
    }
}
