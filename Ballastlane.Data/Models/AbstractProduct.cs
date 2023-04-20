namespace Ballastlane.Data.Models
{
    public abstract class AbstractProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public decimal SellingPrice { get; set; }

        public abstract void ApplyPercentage();
    }
}
