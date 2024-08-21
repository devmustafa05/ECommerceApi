using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
                
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // desing sadece start up da olacak yerler
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
