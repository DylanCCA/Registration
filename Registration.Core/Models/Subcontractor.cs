using System;
using System.ComponentModel.DataAnnotations;

namespace Registration.Core.Models
{
    public class Subcontractor
    {
        [Key]
        public int SubcontractorID { get; set; }
        public string BusinessName { get; set; }
        public string ContactInfo { get; set; }
        public string VerificationStatus { get; set; }
        public string TierLevel { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }
    }
}
