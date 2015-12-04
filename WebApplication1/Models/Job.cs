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

        [Display(Name = "Job Title")]
        public string Title { get; set; }

        [Display(Name = "Job Description")]
        public string Description { get; set; }

        [Display(Name = "Your Email Address")]
        public string Email { get; set; }
        
        [Display(Name = "Pay Rate")]
        public string PayRate { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
    }

    public class JobDBContext : DbContext
    {
        public DbSet<Job> Jobs { get; set;}
    }
}
