using Microsoft.AspNetCore.Mvc;
using Registration.Core.Models;
using Registration.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Registration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ISubcontractorService _subcontractorService;
        private readonly IEquipmentService _equipmentService;
        private readonly IDriverService _driverService;
        private readonly IInsuranceService _insuranceService;
        private readonly IVerificationProgressService _verificationProgressService;

        public RegistrationController(
            ISubcontractorService subcontractorService,
            IEquipmentService equipmentService,
            IDriverService driverService,
            IInsuranceService insuranceService,
            IVerificationProgressService verificationProgressService)
        {
            _subcontractorService = subcontractorService;
            _equipmentService = equipmentService;
            _driverService = driverService;
            _insuranceService = insuranceService;
            _verificationProgressService = verificationProgressService;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitRegistration([FromBody] RegistrationSubmissionDto submission)
        {
            if (submission == null)
            {
                return BadRequest("Registration data is required");
            }

            try
            {
                var subcontractor = new Subcontractor
                {
                    BusinessName = submission.Subcontractor.BusinessName,
                    ContactInfo = submission.Subcontractor.ContactInfo,
                    TierLevel = submission.Subcontractor.TierLevel,
                    VerificationStatus = "Pending",
                    CreatedDate = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                };

                var createdSubcontractor = await _subcontractorService.CreateSubcontractorAsync(subcontractor);

                var steps = new[] { "Business Registration", "Equipment Verification", "Driver Documentation", "Insurance Verification", "Final Approval" };
                foreach (var step in steps)
                {
                    await _verificationProgressService.CreateVerificationProgressAsync(new VerificationProgress
                    {
                        SubcontractorID = createdSubcontractor.SubcontractorID,
                        Step = step,
                        Status = step == "Business Registration" ? "Completed" : "Pending",
                        CompletionDate = step == "Business Registration" ? DateTime.UtcNow : null
                    });
                }

                if (submission.Equipment != null && submission.Equipment.Count > 0)
                {
                    foreach (var equipmentDto in submission.Equipment)
                    {
                        var equipment = new Equipment
                        {
                            SubcontractorID = createdSubcontractor.SubcontractorID,
                            Category = equipmentDto.Category,
                            Type = equipmentDto.Type,
                            Make = equipmentDto.Make,
                            Model = equipmentDto.Model,
                            SerialNumber = equipmentDto.SerialNumber,
                            Year = equipmentDto.Year,
                            Capacity = equipmentDto.Capacity,
                            VerificationStatus = "Pending"
                        };

                        await _equipmentService.CreateEquipmentAsync(equipment);
                    }

                    var equipmentProgress = await _verificationProgressService.GetVerificationProgressBySubcontractorIdAsync(createdSubcontractor.SubcontractorID);
                    var equipmentStep = equipmentProgress.FirstOrDefault(p => p.Step == "Equipment Verification");
                    if (equipmentStep != null)
                    {
                        equipmentStep.Status = "In Progress";
                        await _verificationProgressService.UpdateVerificationProgressAsync(equipmentStep);
                    }
                }

                if (submission.Drivers != null && submission.Drivers.Count > 0)
                {
                    foreach (var driverDto in submission.Drivers)
                    {
                        var driver = new Driver
                        {
                            SubcontractorID = createdSubcontractor.SubcontractorID,
                            LicenseType = driverDto.LicenseType,
                            LicenseState = driverDto.LicenseState,
                            ExpirationDate = driverDto.ExpirationDate,
                            DocumentPath = driverDto.DocumentPath,
                            VerificationStatus = "Pending"
                        };

                        await _driverService.CreateDriverAsync(driver);
                    }

                    var driverProgress = await _verificationProgressService.GetVerificationProgressBySubcontractorIdAsync(createdSubcontractor.SubcontractorID);
                    var driverStep = driverProgress.FirstOrDefault(p => p.Step == "Driver Documentation");
                    if (driverStep != null)
                    {
                        driverStep.Status = "In Progress";
                        await _verificationProgressService.UpdateVerificationProgressAsync(driverStep);
                    }
                }

                if (submission.Insurance != null && submission.Insurance.Count > 0)
                {
                    foreach (var insuranceDto in submission.Insurance)
                    {
                        var insurance = new Insurance
                        {
                            SubcontractorID = createdSubcontractor.SubcontractorID,
                            EquipmentID = insuranceDto.EquipmentID,
                            DocumentPath = insuranceDto.DocumentPath,
                            ExpirationDate = insuranceDto.ExpirationDate,
                            VerificationStatus = "Pending"
                        };

                        await _insuranceService.CreateInsuranceAsync(insurance);
                    }

                    var insuranceProgress = await _verificationProgressService.GetVerificationProgressBySubcontractorIdAsync(createdSubcontractor.SubcontractorID);
                    var insuranceStep = insuranceProgress.FirstOrDefault(p => p.Step == "Insurance Verification");
                    if (insuranceStep != null)
                    {
                        insuranceStep.Status = "In Progress";
                        await _verificationProgressService.UpdateVerificationProgressAsync(insuranceStep);
                    }
                }

                return Ok(new { subcontractorId = createdSubcontractor.SubcontractorID });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

    public class RegistrationSubmissionDto
    {
        public SubcontractorDto Subcontractor { get; set; }
        public List<EquipmentDto> Equipment { get; set; }
        public List<DriverDto> Drivers { get; set; }
        public List<InsuranceDto> Insurance { get; set; }
    }

    public class SubcontractorDto
    {
        public string BusinessName { get; set; }
        public string ContactInfo { get; set; }
        public string TierLevel { get; set; }
    }

    public class EquipmentDto
    {
        public string Category { get; set; }
        public string Type { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public int Year { get; set; }
        public string Capacity { get; set; }
    }

    public class DriverDto
    {
        public string LicenseType { get; set; }
        public string LicenseState { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string DocumentPath { get; set; }
    }

    public class InsuranceDto
    {
        public int EquipmentID { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string DocumentPath { get; set; }
    }
}
