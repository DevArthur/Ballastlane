using Ballastlane.Data.Models.Entities;

namespace Ballastlane.Business.Services
{
    /// <summary>
    /// Interface for product business logic.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// It applies a percentage based on the product type.
        /// </summary>
        /// <param name="product">Product.</param>
        /// <returns>Product</returns>
        void ApplyPercentageByProductType(Product product);

        /// <summary>
        /// It verifies if is trying to update the product type. By business
        /// rule this is not allowed.
        /// </summary>
        /// <param name="currentType">Current product type.</param>
        /// <param name="updatingType">Possible product type the is trying to update</param>
        /// <returns>bool</returns>
        bool IsTypeProductUpdating(string currentType, string updatingType);
    }
}
