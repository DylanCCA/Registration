using Microsoft.AspNetCore.Mvc;
using Registration.Core.Models;
using Registration.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificationProgressController : ControllerBase
    {
        private readonly IVerificationProgressService _verificationProgressService;

        public VerificationProgressController(IVerificationProgressService verificationProgressService)
        {
            _verificationProgressService = verificationProgressService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VerificationProgress>>> GetVerificationProgress()
        {
            var verificationProgress = await _verificationProgressService.GetAllVerificationProgressAsync();
            return Ok(verificationProgress);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VerificationProgress>> GetVerificationProgress(int id)
        {
            var verificationProgress = await _verificationProgressService.GetVerificationProgressByIdAsync(id);

            if (verificationProgress == null)
            {
                return NotFound();
            }

            return Ok(verificationProgress);
        }

        [HttpGet("Subcontractor/{subcontractorId}")]
        public async Task<ActionResult<IEnumerable<VerificationProgress>>> GetVerificationProgressBySubcontractor(int subcontractorId)
        {
            var verificationProgress = await _verificationProgressService.GetVerificationProgressBySubcontractorIdAsync(subcontractorId);
            return Ok(verificationProgress);
        }

        [HttpPost]
        public async Task<ActionResult<VerificationProgress>> CreateVerificationProgress(VerificationProgress verificationProgress)
        {
            var createdVerificationProgress = await _verificationProgressService.CreateVerificationProgressAsync(verificationProgress);
            return CreatedAtAction(nameof(GetVerificationProgress), new { id = createdVerificationProgress.ProgressID }, createdVerificationProgress);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVerificationProgress(int id, VerificationProgress verificationProgress)
        {
            if (id != verificationProgress.ProgressID)
            {
                return BadRequest();
            }

            await _verificationProgressService.UpdateVerificationProgressAsync(verificationProgress);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVerificationProgress(int id)
        {
            await _verificationProgressService.DeleteVerificationProgressAsync(id);
            return NoContent();
        }
    }
}
