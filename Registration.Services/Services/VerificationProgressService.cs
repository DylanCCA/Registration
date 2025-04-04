using Registration.Core.Models;
using Registration.Data.Repositories.Interfaces;
using Registration.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Services.Services
{
    public class VerificationProgressService : IVerificationProgressService
    {
        private readonly IVerificationProgressRepository _verificationProgressRepository;

        public VerificationProgressService(IVerificationProgressRepository verificationProgressRepository)
        {
            _verificationProgressRepository = verificationProgressRepository;
        }

        public async Task<IEnumerable<VerificationProgress>> GetAllVerificationProgressAsync()
        {
            return await _verificationProgressRepository.GetAllAsync();
        }

        public async Task<VerificationProgress> GetVerificationProgressByIdAsync(int id)
        {
            return await _verificationProgressRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<VerificationProgress>> GetVerificationProgressBySubcontractorIdAsync(int subcontractorId)
        {
            return await _verificationProgressRepository.GetBySubcontractorIdAsync(subcontractorId);
        }

        public async Task<VerificationProgress> CreateVerificationProgressAsync(VerificationProgress verificationProgress)
        {
            verificationProgress.Status = "In Progress";
            
            await _verificationProgressRepository.AddAsync(verificationProgress);
            await _verificationProgressRepository.SaveChangesAsync();
            
            return verificationProgress;
        }

        public async Task UpdateVerificationProgressAsync(VerificationProgress verificationProgress)
        {
            await _verificationProgressRepository.UpdateAsync(verificationProgress);
            await _verificationProgressRepository.SaveChangesAsync();
        }

        public async Task DeleteVerificationProgressAsync(int id)
        {
            var verificationProgress = await _verificationProgressRepository.GetByIdAsync(id);
            if (verificationProgress != null)
            {
                await _verificationProgressRepository.DeleteAsync(verificationProgress);
                await _verificationProgressRepository.SaveChangesAsync();
            }
        }
    }
}
