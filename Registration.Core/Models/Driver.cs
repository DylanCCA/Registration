using System;
using System.ComponentModel.DataAnnotations;

namespace Registration.Core.Models
{
    public class Driver
    {
        [Key]
        public int DriverID { get; set; }
        public int SubcontractorID { get; set; }
        public string LicenseType { get; set; }
        public string LicenseState { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string VerificationStatus { get; set; }
        public string DocumentPath { get; set; }
        
        public Subcontractor Subcontractor { get; set; }
    }
}
