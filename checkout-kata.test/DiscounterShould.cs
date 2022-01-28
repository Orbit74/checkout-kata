using checkout_kata.Interfaces;
using checkout_kata.Models;
using checkout_kata.test.Stubs;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace checkout_kata.test
{
    public class DiscounterShould
    {
        private readonly IProductCatalogue _productCatalogue;

        private readonly Discounter _sut;

        public DiscounterShould()
        {
            _productCatalogue = new ProductCatalogueStub();

            _sut = new Discounter(new OfferCatalogueStub());
        }

        [Fact]
        public void ReturnZeroWhenCalculateDiscountIsCalledIfNoProductsAreInput()
        {
            _sut.CalculateDiscount(It.IsAny<IEnumerable<Product>>()).Should().Be(0);
        }

        [Fact]
        public void ReturnZeroWhenCalculateDiscountIsCalledIfNoOfferAvailable()
        {
            var products = _productCatalogue.GetMany("C40", 10);

            _sut.CalculateDiscount(products).Should().Be(0);
        }

        [Fact]
        public void ReturnCorrectDiscountWhenCalculateDiscountIsCalledIfItemsAddedOutOfOrder()
        {
            var product1 = _productCatalogue.Get("B15");
            var product2 = _productCatalogue.Get("A99");
            var product3 = _productCatalogue.Get("B15");

            var products = new List<Product> { product1, product2, product3 };

            _sut.CalculateDiscount(products).Should().Be(0.15);
        }

        [Theory]
        [InlineData("A99", 3, 0.20)]
        [InlineData("B15", 2, 0.15)]
        [InlineData("A99", 6, 0.40)]
        [InlineData("B15", 4, 0.30)]
        [InlineData("A99", 7, 0.40)]
        [InlineData("B15", 5, 0.30)]
        [InlineData("A99", 100, 6.60)]
        [InlineData("B15", 101, 7.50)]
        public void ReturnCorrectDiscountWhenCalculateDiscountIsCalledIfProductsQualify(string sku, int quantity, double expectedDiscount)
        {
            var products = _productCatalogue.GetMany(sku, quantity); 

            _sut.CalculateDiscount(products).Should().Be(expectedDiscount);
        }
    }
}
