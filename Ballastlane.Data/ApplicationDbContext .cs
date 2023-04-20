using Ballastlane.Data.DataSeeding;
using Ballastlane.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ballastlane.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Data seeding
            DatabaseData.Seed(modelBuilder);

            // Fluent API configurations.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
