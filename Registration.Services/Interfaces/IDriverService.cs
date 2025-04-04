using Registration.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Services.Interfaces
{
    public interface IDriverService
    {
        Task<IEnumerable<Driver>> GetAllDriversAsync();
        Task<Driver> GetDriverByIdAsync(int id);
        Task<IEnumerable<Driver>> GetDriversBySubcontractorIdAsync(int subcontractorId);
        Task<Driver> CreateDriverAsync(Driver driver);
        Task UpdateDriverAsync(Driver driver);
        Task DeleteDriverAsync(int id);
    }
}
