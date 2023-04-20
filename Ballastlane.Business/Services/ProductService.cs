using Ballastlane.Data.Models;
using Ballastlane.Data.Models.Entities;

namespace Ballastlane.Business.Services
{
    /// <summary>
    /// Class that implements IProductService
    /// </summary>
    public class ProductService : IProductService
    {
        /// <summary>
        /// It applies a percentage based on the product type.
        /// </summary>
        /// <param name="product">Product.</param>
        /// <returns>Product</returns>
        public void ApplyPercentageByProductType(Product product)
        {
            switch (product.Type)
            {
                case ProductType.National:

                    AbstractProduct nationalProduct = new NationalProduct(product);
                    nationalProduct.ApplyPercentage();
                    break;

                case ProductType.International:

                    AbstractProduct internationalProduct = new InternationalProduct(product);
                    internationalProduct.ApplyPercentage();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// It verifies if is trying to update the product type. By business
        /// rule this is not allowed.
        /// </summary>
        /// <param name="currentType">Current product type.</param>
        /// <param name="updatingType">Possible product type the is trying to update</param>
        /// <returns>bool</returns>
        public bool IsTypeProductUpdating(string currentType, string updatingType) => !currentType.Equals(updatingType);


    }
}
