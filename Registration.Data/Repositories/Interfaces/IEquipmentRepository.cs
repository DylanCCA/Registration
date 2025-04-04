using Registration.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Data.Repositories.Interfaces
{
    public interface IEquipmentRepository : IRepository<Equipment>
    {
        Task<IEnumerable<Equipment>> GetBySubcontractorIdAsync(int subcontractorId);
    }
}
