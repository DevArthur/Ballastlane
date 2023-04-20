using Ballastlane.Data.Models.Entities;

namespace Ballastlane.Data.Models
{
    /// <summary>
    /// /// Abstraction of an international product.
    /// </summary>
    public class InternationalProduct : AbstractProduct
    {
        private readonly Product _product;

        public InternationalProduct(Product product)
        {
            _product = product;
        }

        /// <summary>
        /// It applies correspond percentage for an international product.
        /// </summary>
        /// <returns>Product</returns>
        public override void ApplyPercentage() => _product.SellingPrice = _product.Price + (_product.Price * ProductPercentages.International12);
    }
}
