using Microsoft.EntityFrameworkCore;
using Registration.Core.Models;
using Registration.Data.Context;
using Registration.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Data.Repositories
{
    public class DriverRepository : Repository<Driver>, IDriverRepository
    {
        public DriverRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Driver>> GetBySubcontractorIdAsync(int subcontractorId)
        {
            return await _context.Drivers
                .Where(d => d.SubcontractorID == subcontractorId)
                .ToListAsync();
        }
    }
}
