using checkout_kata.Models;

namespace checkout_kata.Interfaces
{
    public interface IProductCatalogue
    {
        IEnumerable<Product> Get();

        Product? Get(string sku);
    }
}
