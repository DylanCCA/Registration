using Registration.Core.Models;
using Registration.Data.Repositories.Interfaces;
using Registration.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Services.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task<IEnumerable<Equipment>> GetAllEquipmentAsync()
        {
            return await _equipmentRepository.GetAllAsync();
        }

        public async Task<Equipment> GetEquipmentByIdAsync(int id)
        {
            return await _equipmentRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Equipment>> GetEquipmentBySubcontractorIdAsync(int subcontractorId)
        {
            return await _equipmentRepository.GetBySubcontractorIdAsync(subcontractorId);
        }

        public async Task<Equipment> CreateEquipmentAsync(Equipment equipment)
        {
            equipment.VerificationStatus = "Pending";
            
            await _equipmentRepository.AddAsync(equipment);
            await _equipmentRepository.SaveChangesAsync();
            
            return equipment;
        }

        public async Task UpdateEquipmentAsync(Equipment equipment)
        {
            await _equipmentRepository.UpdateAsync(equipment);
            await _equipmentRepository.SaveChangesAsync();
        }

        public async Task DeleteEquipmentAsync(int id)
        {
            var equipment = await _equipmentRepository.GetByIdAsync(id);
            if (equipment != null)
            {
                await _equipmentRepository.DeleteAsync(equipment);
                await _equipmentRepository.SaveChangesAsync();
            }
        }
    }
}
