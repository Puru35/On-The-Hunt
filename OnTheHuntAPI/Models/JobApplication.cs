using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnTheHunt.Models
{
    public class JobApplication
    /* 
    This class is the model for the JobApplication table in the database.    
     */
    {
        [Key]
        public int JobID { get; set; }

        [Required]
        [MaxLength(255)]
        public string? CompanyName { get; set; }

        [Required]
        public string? JobTitle { get; set; }

        public string? JobDescription { get; set; }

        public DateTime ApplicationDate { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Status { get; set; }

        public string? Notes { get; set; }

        public int UserID { get; set; }

        public int Password { get; set; }

        public string? ResumePath { get; set; }
    }
}