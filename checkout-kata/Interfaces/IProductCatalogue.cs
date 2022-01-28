using checkout_kata.Models;

namespace checkout_kata.Interfaces
{
    public interface IProductCatalogue
    {
        IEnumerable<Product> GetMany(string sku, int quantity);
        Product? Get(string sku);
    }
}
