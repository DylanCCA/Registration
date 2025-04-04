using Registration.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Services.Interfaces
{
    public interface ISubcontractorService
    {
        Task<IEnumerable<Subcontractor>> GetAllSubcontractorsAsync();
        Task<Subcontractor> GetSubcontractorByIdAsync(int id);
        Task<Subcontractor> CreateSubcontractorAsync(Subcontractor subcontractor);
        Task UpdateSubcontractorAsync(Subcontractor subcontractor);
        Task DeleteSubcontractorAsync(int id);
    }
}
