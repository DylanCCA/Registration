using Registration.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Services.Interfaces
{
    public interface IEquipmentService
    {
        Task<IEnumerable<Equipment>> GetAllEquipmentAsync();
        Task<Equipment> GetEquipmentByIdAsync(int id);
        Task<IEnumerable<Equipment>> GetEquipmentBySubcontractorIdAsync(int subcontractorId);
        Task<Equipment> CreateEquipmentAsync(Equipment equipment);
        Task UpdateEquipmentAsync(Equipment equipment);
        Task DeleteEquipmentAsync(int id);
    }
}
