using Registration.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Data.Repositories.Interfaces
{
    public interface IVerificationProgressRepository : IRepository<VerificationProgress>
    {
        Task<IEnumerable<VerificationProgress>> GetBySubcontractorIdAsync(int subcontractorId);
    }
}
