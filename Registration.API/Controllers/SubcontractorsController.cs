using Microsoft.AspNetCore.Mvc;
using Registration.Core.Models;
using Registration.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcontractorsController : ControllerBase
    {
        private readonly ISubcontractorService _subcontractorService;

        public SubcontractorsController(ISubcontractorService subcontractorService)
        {
            _subcontractorService = subcontractorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subcontractor>>> GetSubcontractors()
        {
            var subcontractors = await _subcontractorService.GetAllSubcontractorsAsync();
            return Ok(subcontractors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subcontractor>> GetSubcontractor(int id)
        {
            var subcontractor = await _subcontractorService.GetSubcontractorByIdAsync(id);

            if (subcontractor == null)
            {
                return NotFound();
            }

            return Ok(subcontractor);
        }

        [HttpPost]
        public async Task<ActionResult<Subcontractor>> CreateSubcontractor(Subcontractor subcontractor)
        {
            var createdSubcontractor = await _subcontractorService.CreateSubcontractorAsync(subcontractor);
            return CreatedAtAction(nameof(GetSubcontractor), new { id = createdSubcontractor.SubcontractorID }, createdSubcontractor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubcontractor(int id, Subcontractor subcontractor)
        {
            if (id != subcontractor.SubcontractorID)
            {
                return BadRequest();
            }

            await _subcontractorService.UpdateSubcontractorAsync(subcontractor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubcontractor(int id)
        {
            await _subcontractorService.DeleteSubcontractorAsync(id);
            return NoContent();
        }
    }
}
