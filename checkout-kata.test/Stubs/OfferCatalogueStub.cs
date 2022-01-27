using checkout_kata.Interfaces;
using checkout_kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace checkout_kata.test.Stubs
{
    public class OfferCatalogueStub : IOfferCatalogue
    {
        public IEnumerable<Offer> Get()
        {
            return _offers;
        }

        public Offer? Get(string sku)
        {
            return _offers.FirstOrDefault(x => x.Sku.Equals(sku, StringComparison.OrdinalIgnoreCase));
        }

        private List<Offer> _offers = new List<Offer>
        {
            new Offer
            {
                Sku = "A99",
                Quantity = 3,
                Discount = 0.20
            },
            new Offer
            {
                Sku = "B15",
                Quantity = 2,
                Discount = 0.15
            }
        };
    }
}
