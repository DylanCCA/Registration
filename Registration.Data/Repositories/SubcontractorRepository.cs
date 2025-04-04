using Microsoft.EntityFrameworkCore;
using Registration.Core.Models;
using Registration.Data.Context;
using Registration.Data.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Registration.Data.Repositories
{
    public class SubcontractorRepository : Repository<Subcontractor>, ISubcontractorRepository
    {
        public SubcontractorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Subcontractor> GetWithDetailsAsync(int id)
        {
            return await _context.Subcontractors
                .FirstOrDefaultAsync(s => s.SubcontractorID == id);
        }
    }
}
