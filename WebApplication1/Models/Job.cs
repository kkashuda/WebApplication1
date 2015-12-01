using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace WebApplication1.Models
{
    public class Job
    {
        public string employer { get; set; }
        public string title { get; set; }
        public string description { get; set;}
        public Boolean interested { get; set; }
    }
    public class JobDBContext : DbContext
    {
        public DbSet<Job> Jobs { get; set;}
    }
}
