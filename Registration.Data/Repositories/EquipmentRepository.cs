using Microsoft.EntityFrameworkCore;
using Registration.Core.Models;
using Registration.Data.Context;
using Registration.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Data.Repositories
{
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Equipment>> GetBySubcontractorIdAsync(int subcontractorId)
        {
            return await _context.Equipment
                .Where(e => e.SubcontractorID == subcontractorId)
                .ToListAsync();
        }
    }
}
