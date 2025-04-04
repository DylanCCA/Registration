using Registration.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Data.Repositories.Interfaces
{
    public interface IInsuranceRepository : IRepository<Insurance>
    {
        Task<IEnumerable<Insurance>> GetBySubcontractorIdAsync(int subcontractorId);
        Task<IEnumerable<Insurance>> GetByEquipmentIdAsync(int equipmentId);
    }
}
