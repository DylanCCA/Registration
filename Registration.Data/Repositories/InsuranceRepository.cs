using Microsoft.EntityFrameworkCore;
using Registration.Core.Models;
using Registration.Data.Context;
using Registration.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Data.Repositories
{
    public class InsuranceRepository : Repository<Insurance>, IInsuranceRepository
    {
        public InsuranceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Insurance>> GetBySubcontractorIdAsync(int subcontractorId)
        {
            return await _context.Insurance
                .Where(i => i.SubcontractorID == subcontractorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Insurance>> GetByEquipmentIdAsync(int equipmentId)
        {
            return await _context.Insurance
                .Where(i => i.EquipmentID == equipmentId)
                .ToListAsync();
        }
    }
}
