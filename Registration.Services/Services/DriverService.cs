using Registration.Core.Models;
using Registration.Data.Repositories.Interfaces;
using Registration.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Services.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<IEnumerable<Driver>> GetAllDriversAsync()
        {
            return await _driverRepository.GetAllAsync();
        }

        public async Task<Driver> GetDriverByIdAsync(int id)
        {
            return await _driverRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Driver>> GetDriversBySubcontractorIdAsync(int subcontractorId)
        {
            return await _driverRepository.GetBySubcontractorIdAsync(subcontractorId);
        }

        public async Task<Driver> CreateDriverAsync(Driver driver)
        {
            driver.VerificationStatus = "Pending";
            
            await _driverRepository.AddAsync(driver);
            await _driverRepository.SaveChangesAsync();
            
            return driver;
        }

        public async Task UpdateDriverAsync(Driver driver)
        {
            await _driverRepository.UpdateAsync(driver);
            await _driverRepository.SaveChangesAsync();
        }

        public async Task DeleteDriverAsync(int id)
        {
            var driver = await _driverRepository.GetByIdAsync(id);
            if (driver != null)
            {
                await _driverRepository.DeleteAsync(driver);
                await _driverRepository.SaveChangesAsync();
            }
        }
    }
}
