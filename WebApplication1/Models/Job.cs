using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Job
    {
        [Key]
        public string Employer { get; set; }
        public string Title { get; set; }
        public string Description { get; set;}
        public Boolean Interested { get; set; }
    }
    public class JobDBContext : DbContext
    {
        public DbSet<Job> Jobs { get; set;}
    }
}
