using Registration.Core.Models;
using Registration.Data.Repositories.Interfaces;
using Registration.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Services.Services
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IInsuranceRepository _insuranceRepository;

        public InsuranceService(IInsuranceRepository insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;
        }

        public async Task<IEnumerable<Insurance>> GetAllInsuranceAsync()
        {
            return await _insuranceRepository.GetAllAsync();
        }

        public async Task<Insurance> GetInsuranceByIdAsync(int id)
        {
            return await _insuranceRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Insurance>> GetInsuranceBySubcontractorIdAsync(int subcontractorId)
        {
            return await _insuranceRepository.GetBySubcontractorIdAsync(subcontractorId);
        }

        public async Task<IEnumerable<Insurance>> GetInsuranceByEquipmentIdAsync(int equipmentId)
        {
            return await _insuranceRepository.GetByEquipmentIdAsync(equipmentId);
        }

        public async Task<Insurance> CreateInsuranceAsync(Insurance insurance)
        {
            insurance.VerificationStatus = "Pending";
            
            await _insuranceRepository.AddAsync(insurance);
            await _insuranceRepository.SaveChangesAsync();
            
            return insurance;
        }

        public async Task UpdateInsuranceAsync(Insurance insurance)
        {
            await _insuranceRepository.UpdateAsync(insurance);
            await _insuranceRepository.SaveChangesAsync();
        }

        public async Task DeleteInsuranceAsync(int id)
        {
            var insurance = await _insuranceRepository.GetByIdAsync(id);
            if (insurance != null)
            {
                await _insuranceRepository.DeleteAsync(insurance);
                await _insuranceRepository.SaveChangesAsync();
            }
        }
    }
}
