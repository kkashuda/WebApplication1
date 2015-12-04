using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using SendGrid;

namespace WebApplication1.Models
{
    public class Job
    {
        [Key]
        public string Employer { get; set; }

        [Required, Display(Name = "Job Title")]
        public string Title { get; set; }

        [Required, Display(Name = "Job Description")]
        public string Description { get; set; }

        [Required, Display(Name = "Your Email Address")]
        public string Email { get; set; }
        
        public string PayRate { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required, Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
    }
    public class JobDBContext : DbContext
    {
        public DbSet<Job> Jobs { get; set;}
    }
}
