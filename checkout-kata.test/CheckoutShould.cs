using checkout_kata.Interfaces;
using checkout_kata.Models;
using checkout_kata.test.Stubs;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace checkout_kata.test
{
    public class CheckoutShould
    {
        private readonly Mock<IDiscounter> _mockDiscounter;

        private readonly Checkout _sut;

        public CheckoutShould()
        {
            _mockDiscounter = new Mock<IDiscounter>();
            _sut = new Checkout(new ProductCatalogueStub(), _mockDiscounter.Object);
        }

        [Fact]
        public void ReturnZeroTotalWhenNoProductsScanned()
        {
            _sut.SubTotal.Should().Be(0);
            _sut.TotalWithOffers.Should().Be(0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("Invalid")]
        public void ReturnZeroTotalWhenInvalidProductIsScanned(string sku)
        {
            _sut.Scan(sku);

            _sut.SubTotal.Should().Be(0);
            _sut.TotalWithOffers.Should().Be(0);
            _mockDiscounter.Verify(v => v.CalculateDiscount(It.IsAny<IEnumerable<Product>>()), Times.Never);
        }

        [Theory]
        [InlineData("A99")]
        [InlineData("a99")]
        public void ReturnCorrectTotalsWhenOneProductIsScanned(string sku)
        {
            _sut.Scan(sku);

            _sut.SubTotal.Should().Be(0.50M);
            _sut.TotalWithOffers.Should().Be(0.50M);
            _mockDiscounter.Verify(v => v.CalculateDiscount(It.IsAny<IEnumerable<Product>>()), Times.Once);
        }

        [Fact]
        public void ReturnCorrectTotalsWhenMultipleProductAreScanned()
        {
            _sut.Scan("A99");
            _sut.Scan("B15");
            _sut.Scan("C40");

            _sut.SubTotal.Should().Be(1.40M);
            _sut.TotalWithOffers.Should().Be(1.40M);
            _mockDiscounter.Verify(v => v.CalculateDiscount(It.IsAny<IEnumerable<Product>>()), Times.Exactly(3));
        }

        [Fact]
        public void ReturnCorrectTotalsWhenQualifyingProductsAreScanned()
        {
            GivenDiscountOf(0.20M);

            _sut.Scan("A99", 3);

            _sut.SubTotal.Should().Be(1.50M);
            _sut.TotalWithOffers.Should().Be(1.3M);
            _mockDiscounter.Verify(v => v.CalculateDiscount(It.IsAny<IEnumerable<Product>>()), Times.Once);
        }

        private void GivenDiscountOf(decimal discount)
        {
            _mockDiscounter.Setup(x => x.CalculateDiscount(It.IsAny<IEnumerable<Product>>()))
                .Returns(discount);
        }
    }
}