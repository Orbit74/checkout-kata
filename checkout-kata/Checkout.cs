using checkout_kata.Interfaces;
using checkout_kata.Models;

namespace checkout_kata
{
    public class Checkout : ICheckout
    {
        private readonly IProductCatalogue _productCatalogue;
        private readonly IDiscounter _discounter;
        private readonly Order _order;

        public double SubTotal => _order.SubTotal;
        public double TotalWithOffers => _order.Total;

        public Checkout(IProductCatalogue productCatalogue, IDiscounter discounter)
        {
            _productCatalogue = productCatalogue;
            _discounter = discounter;
            _order = new Order();
        }

        public void Scan(string sku, int quantity = 1)
        {
            if (quantity < 1) return;

            var products = _productCatalogue.GetMany(sku, quantity);
            if (products.Any())
            {
                _order.Items.AddRange(products);
                _order.TotalDiscount = _discounter.CalculateDiscount(_order.Items);
            }
        }
    }
}