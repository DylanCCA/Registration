using Microsoft.AspNetCore.Mvc;
using Registration.Core.Models;
using Registration.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipment>>> GetEquipment()
        {
            var equipment = await _equipmentService.GetAllEquipmentAsync();
            return Ok(equipment);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Equipment>> GetEquipment(int id)
        {
            var equipment = await _equipmentService.GetEquipmentByIdAsync(id);

            if (equipment == null)
            {
                return NotFound();
            }

            return Ok(equipment);
        }

        [HttpGet("Subcontractor/{subcontractorId}")]
        public async Task<ActionResult<IEnumerable<Equipment>>> GetEquipmentBySubcontractor(int subcontractorId)
        {
            var equipment = await _equipmentService.GetEquipmentBySubcontractorIdAsync(subcontractorId);
            return Ok(equipment);
        }

        [HttpPost]
        public async Task<ActionResult<Equipment>> CreateEquipment(Equipment equipment)
        {
            var createdEquipment = await _equipmentService.CreateEquipmentAsync(equipment);
            return CreatedAtAction(nameof(GetEquipment), new { id = createdEquipment.EquipmentID }, createdEquipment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEquipment(int id, Equipment equipment)
        {
            if (id != equipment.EquipmentID)
            {
                return BadRequest();
            }

            await _equipmentService.UpdateEquipmentAsync(equipment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            await _equipmentService.DeleteEquipmentAsync(id);
            return NoContent();
        }
    }
}
