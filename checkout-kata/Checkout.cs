using checkout_kata.Interfaces;
using checkout_kata.Models;

namespace checkout_kata
{
    public class Checkout : ICheckout
    {
        private readonly IProductCatalogue _productCatalogue;
        private readonly IDiscounter _discounter;
        private readonly Order _order;

        public Checkout(IProductCatalogue productCatalogue, IDiscounter discounter)
        {
            _productCatalogue = productCatalogue;
            _discounter = discounter;
            _order = new Order();
        }

        public void Scan(string sku)
        {
            var product = _productCatalogue.Get(sku);
            if (product != null)
            {
                _order.Items.Add(product);
                _order.TotalDiscount = _discounter.CalculateDiscount(_order.Items);
            }
        }

        public double GetTotal()
        {
            return _order.Total;
        }
    }
}