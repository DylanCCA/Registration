using System;
using System.ComponentModel.DataAnnotations;

namespace Registration.Core.Models
{
    public class Insurance
    {
        [Key]
        public int InsuranceID { get; set; }
        public int EquipmentID { get; set; }
        public int SubcontractorID { get; set; }
        public string DocumentPath { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string VerificationStatus { get; set; }
        
        public Equipment Equipment { get; set; }
        public Subcontractor Subcontractor { get; set; }
    }
}
