using Registration.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Services.Interfaces
{
    public interface IInsuranceService
    {
        Task<IEnumerable<Insurance>> GetAllInsuranceAsync();
        Task<Insurance> GetInsuranceByIdAsync(int id);
        Task<IEnumerable<Insurance>> GetInsuranceBySubcontractorIdAsync(int subcontractorId);
        Task<IEnumerable<Insurance>> GetInsuranceByEquipmentIdAsync(int equipmentId);
        Task<Insurance> CreateInsuranceAsync(Insurance insurance);
        Task UpdateInsuranceAsync(Insurance insurance);
        Task DeleteInsuranceAsync(int id);
    }
}
