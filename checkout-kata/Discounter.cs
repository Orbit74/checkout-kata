using checkout_kata.Interfaces;
using checkout_kata.Models;

namespace checkout_kata
{
    public class Discounter : IDiscounter
    {
        private readonly IOfferCatalogue _offerCatalogue;

        public Discounter(IOfferCatalogue offerCatalogue)
        {
            _offerCatalogue = offerCatalogue;
        }

        public double CalculateDiscount(IEnumerable<Product> products)
        {
            double discount = 0;

            var productDictionary = products.ToDictionary(x => x.Sku, x => x);

            foreach(var product in productDictionary)
            {
                var offer = _offerCatalogue.Get(product.Key);
                if (offer != null)
                {
                    // increment the discount
                }

            }

            return discount;
        }
    }
}
