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

        public decimal CalculateDiscount(IEnumerable<Product> products)
        {
            if (products == null) { return 0; }

            decimal discount = 0;

            var productGrouping = products.GroupBy(x => x.Sku);

            foreach(var groupedProduct in productGrouping)
            {
                var offer = _offerCatalogue.Get(groupedProduct.Key);
                if (offer != null)
                {
                    discount += GetDiscount(offer, groupedProduct);
                }
            }

            return discount;
        }

        static decimal GetDiscount(Offer offer, IEnumerable<Product> products)
        {
            if (products.Count() >= offer.Quantity)
            {
                var discountMultiplier = products.Count() / offer.Quantity;

                return Math.Round(offer.Discount * discountMultiplier, 2);
            }

            return 0;
        }
    }
}
