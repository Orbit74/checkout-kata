using checkout_kata.Interfaces;
using checkout_kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace checkout_kata.test.Stubs
{
    public class ProductCatalogueStub : IProductCatalogue
    {
        public IEnumerable<Product> Get()
        {
            return _products;
        }

        public Product? Get(string sku)
        {
            return _products.FirstOrDefault(x => x.Sku.Equals(sku, StringComparison.OrdinalIgnoreCase));
        }

        private List<Product> _products = new List<Product>
        {
            new Product
            {
                Sku = "A99",
                UnitPrice = 0.50M
            },
            new Product
            {
                Sku = "B15",
                UnitPrice = 0.30M
            },
            new Product
            {
                Sku = "C40",
                UnitPrice = 0.60M
            }
        };
    }
}
