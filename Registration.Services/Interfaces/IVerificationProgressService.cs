using Registration.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Services.Interfaces
{
    public interface IVerificationProgressService
    {
        Task<IEnumerable<VerificationProgress>> GetAllVerificationProgressAsync();
        Task<VerificationProgress> GetVerificationProgressByIdAsync(int id);
        Task<IEnumerable<VerificationProgress>> GetVerificationProgressBySubcontractorIdAsync(int subcontractorId);
        Task<VerificationProgress> CreateVerificationProgressAsync(VerificationProgress verificationProgress);
        Task UpdateVerificationProgressAsync(VerificationProgress verificationProgress);
        Task DeleteVerificationProgressAsync(int id);
    }
}
