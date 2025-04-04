using Microsoft.EntityFrameworkCore;
using Registration.Core.Models;
using Registration.Data.Context;
using Registration.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Data.Repositories
{
    public class VerificationProgressRepository : Repository<VerificationProgress>, IVerificationProgressRepository
    {
        public VerificationProgressRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<VerificationProgress>> GetBySubcontractorIdAsync(int subcontractorId)
        {
            return await _context.VerificationProgress
                .Where(v => v.SubcontractorID == subcontractorId)
                .ToListAsync();
        }
    }
}
