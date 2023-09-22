using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ElectronicShop.Models
{
        public class ElectronicContext : DbContext
        {
            public ElectronicContext(DbContextOptions<ElectronicContext> options)
                : base(options)
            { }

            public DbSet<Customer> Customers { get; set; }

            public DbSet<Product> Products { get; set; }

            public DbSet<Order> Orders { get; set; }

        }
   
}
