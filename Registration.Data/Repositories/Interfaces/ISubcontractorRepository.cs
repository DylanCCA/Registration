using Registration.Core.Models;
using System.Threading.Tasks;

namespace Registration.Data.Repositories.Interfaces
{
    public interface ISubcontractorRepository : IRepository<Subcontractor>
    {
        Task<Subcontractor> GetWithDetailsAsync(int id);
    }
}
