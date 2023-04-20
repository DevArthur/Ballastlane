using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ballastlane.Data.Models.Entities
{
    /// <summary>
    /// Parent abstraction of a product.
    /// </summary>
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        [MaxLength(120)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(15)]
        public string Type { get; set; }

        [Precision(precision: 10, scale: 2)]
        public decimal Price { get; set; }

        [Precision(precision: 10, scale: 2)]
        public decimal SellingPrice { get; set; }
    }
}
