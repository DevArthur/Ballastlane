using Ballastlane.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ballastlane.Data.DataSeeding
{
    public class DatabaseData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var guiness = new Product
            {
                Id = 1,
                Name = "Cerveza",
                Brand = "Guiness",
                Type = "International",
                Price = 5,
                SellingPrice = 5.6M
            };

            var corona = new Product
            {
                Id = 2,
                Name = "Cerveza",
                Brand = "Corona",
                Type = "National",
                Price = 3.5M,
                SellingPrice = 3.8M
            };

            var jumex = new Product
            {
                Id = 3,
                Name = "Jugo",
                Brand = "Jumex",
                Type = "National",
                Price = 3M,
                SellingPrice = 3.3M
            };

            modelBuilder.Entity<Product>().HasData(guiness, corona, jumex);

            var owner = new User
            {
                Id = 1,
                Name = "Arturo",
                LastName = "López",
                Email = "dev.lopez.alcaraz@gmail.com",
                Password = "@rturo"
            };

            modelBuilder.Entity<User>().HasData(owner);
        }
    }
}
