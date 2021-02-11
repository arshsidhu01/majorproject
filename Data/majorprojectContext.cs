using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using majorproject.Models;

namespace majorproject.Data
{
    public class majorprojectContext : DbContext
    {
        public majorprojectContext (DbContextOptions<majorprojectContext> options)
            : base(options)
        {
        }

        public DbSet<majorproject.Models.Products> Products { get; set; }

        public DbSet<majorproject.Models.Customers> Customers { get; set; }

        public DbSet<majorproject.Models.Location> Location { get; set; }

        public DbSet<majorproject.Models.Staffs> Staffs { get; set; }

        public DbSet<majorproject.Models.Sells> Sells { get; set; }
    }
}
