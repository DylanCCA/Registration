using Registration.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Data.Repositories.Interfaces
{
    public interface IDriverRepository : IRepository<Driver>
    {
        Task<IEnumerable<Driver>> GetBySubcontractorIdAsync(int subcontractorId);
    }
}
