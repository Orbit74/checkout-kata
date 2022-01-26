using checkout_kata.Interfaces;
using checkout_kata.Models;

namespace checkout_kata
{
    public class Checkout : ICheckout
    {
        private readonly IProductCatalogue _productCatalogue;
        private readonly List<Product> _items;

        public Checkout(IProductCatalogue productCatalogue)
        {
            _productCatalogue = productCatalogue;
            _items = new List<Product>();
        }

        public void Scan(string sku)
        {
            var product = _productCatalogue.Get(sku);
            if (product != null)
            {
                _items.Add(product);
            }
        }

        public decimal GetTotal()
        {
            return _items.Sum(x => x.UnitPrice);
        }
    }
}