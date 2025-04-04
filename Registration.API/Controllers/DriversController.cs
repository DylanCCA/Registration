using Microsoft.AspNetCore.Mvc;
using Registration.Core.Models;
using Registration.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriversController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
        {
            var drivers = await _driverService.GetAllDriversAsync();
            return Ok(drivers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetDriver(int id)
        {
            var driver = await _driverService.GetDriverByIdAsync(id);

            if (driver == null)
            {
                return NotFound();
            }

            return Ok(driver);
        }

        [HttpGet("Subcontractor/{subcontractorId}")]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDriversBySubcontractor(int subcontractorId)
        {
            var drivers = await _driverService.GetDriversBySubcontractorIdAsync(subcontractorId);
            return Ok(drivers);
        }

        [HttpPost]
        public async Task<ActionResult<Driver>> CreateDriver(Driver driver)
        {
            var createdDriver = await _driverService.CreateDriverAsync(driver);
            return CreatedAtAction(nameof(GetDriver), new { id = createdDriver.DriverID }, createdDriver);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDriver(int id, Driver driver)
        {
            if (id != driver.DriverID)
            {
                return BadRequest();
            }

            await _driverService.UpdateDriverAsync(driver);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            await _driverService.DeleteDriverAsync(id);
            return NoContent();
        }
    }
}
