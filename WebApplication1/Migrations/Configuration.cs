namespace WebApplication1.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected void Seed(JobDBContext context)
        {
            context.Jobs.AddOrUpdate(i => i.Employer,
                new Job
                {
                    Employer = "Michaels",
                    Title = "Cashier",
                    Description = "work register and answer phone",
                    Email = "info@michaels.com"
                },

                 new Job
                 {
                     Employer = "The Limited",
                     Title = "Sales Associate",
                     Description = "work the wardrobe and sales floor",
                     Email = "info@thelimited.com"
                 },

                 new Job
                 {
                     Employer = "Walmart",
                     Title = "Manager",
                     Description = "manage customer service",
                     Email = "info@walmart.com"
                 }
           );

        }
    }
}
