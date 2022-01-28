using checkout_kata.Interfaces;
using checkout_kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace checkout_kata.test.Stubs
{
    public class ProductCatalogueStub : IProductCatalogue
    {
        public Product? Get(string sku)
        {
            return _products.FirstOrDefault(x => x.Sku.Equals(sku, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Product> GetMany(string sku, int quantity)
        {
            var result = new List<Product>();
            var product = Get(sku);

            if (product != null)
            {
                for (int i = 0; i < quantity; i++)
                {
                    result.Add(product);
                }
            }

            return result;
        }

        static List<Product> _products = new List<Product>
        {
            new Product
            {
                Sku = "A99",
                UnitPrice = 0.50
            },
            new Product
            {
                Sku = "B15",
                UnitPrice = 0.30
            },
            new Product
            {
                Sku = "C40",
                UnitPrice = 0.60
            }
        };
    }
}
