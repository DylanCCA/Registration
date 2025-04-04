using System;
using System.ComponentModel.DataAnnotations;

namespace Registration.Core.Models
{
    public class Equipment
    {
        [Key]
        public int EquipmentID { get; set; }
        public int SubcontractorID { get; set; }
        public string Category { get; set; } // Push/LoadHaul/Leaner/Grinding/HaulOut
        public string Type { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public int Year { get; set; }
        public string Capacity { get; set; }
        public string VerificationStatus { get; set; }
        
        public Subcontractor Subcontractor { get; set; }
    }
}
