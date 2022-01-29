using checkout_kata.Models;

namespace checkout_kata.Interfaces
{
    public interface IProductCatalogue
    {
        /// <summary>
        /// Gets the requested number of products from the catalogue.
        /// </summary>
        /// <param name="sku">Product Identifier</param>
        /// <param name="quantity">The number of products to return</param>
        /// <returns></returns>
        IEnumerable<Product> GetMany(string sku, int quantity);

        /// <summary>
        /// Get a single product from the catalogue.
        /// </summary>
        /// <param name="sku">Product identifier</param>
        /// <returns>Product or null</returns>
        Product? Get(string sku);
    }
}
