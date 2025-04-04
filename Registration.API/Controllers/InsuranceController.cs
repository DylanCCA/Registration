using Microsoft.AspNetCore.Mvc;
using Registration.Core.Models;
using Registration.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Insurance>>> GetInsurance()
        {
            var insurance = await _insuranceService.GetAllInsuranceAsync();
            return Ok(insurance);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Insurance>> GetInsurance(int id)
        {
            var insurance = await _insuranceService.GetInsuranceByIdAsync(id);

            if (insurance == null)
            {
                return NotFound();
            }

            return Ok(insurance);
        }

        [HttpGet("Subcontractor/{subcontractorId}")]
        public async Task<ActionResult<IEnumerable<Insurance>>> GetInsuranceBySubcontractor(int subcontractorId)
        {
            var insurance = await _insuranceService.GetInsuranceBySubcontractorIdAsync(subcontractorId);
            return Ok(insurance);
        }

        [HttpGet("Equipment/{equipmentId}")]
        public async Task<ActionResult<IEnumerable<Insurance>>> GetInsuranceByEquipment(int equipmentId)
        {
            var insurance = await _insuranceService.GetInsuranceByEquipmentIdAsync(equipmentId);
            return Ok(insurance);
        }

        [HttpPost]
        public async Task<ActionResult<Insurance>> CreateInsurance(Insurance insurance)
        {
            var createdInsurance = await _insuranceService.CreateInsuranceAsync(insurance);
            return CreatedAtAction(nameof(GetInsurance), new { id = createdInsurance.InsuranceID }, createdInsurance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInsurance(int id, Insurance insurance)
        {
            if (id != insurance.InsuranceID)
            {
                return BadRequest();
            }

            await _insuranceService.UpdateInsuranceAsync(insurance);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurance(int id)
        {
            await _insuranceService.DeleteInsuranceAsync(id);
            return NoContent();
        }
    }
}
