using System;
using System.ComponentModel.DataAnnotations;

namespace Registration.Core.Models
{
    public class VerificationProgress
    {
        [Key]
        public int ProgressID { get; set; }
        public int SubcontractorID { get; set; }
        public string Step { get; set; }
        public string Status { get; set; }
        public DateTime? CompletionDate { get; set; }
        
        public Subcontractor Subcontractor { get; set; }
    }
}
