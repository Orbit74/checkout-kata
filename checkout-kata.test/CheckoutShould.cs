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

        [Fact]
        public void ReturnZeroTotalWhenInvalidProductIsScanned()
        {
            _sut.Scan("Invalid");

            _sut.SubTotal.Should().Be(0);
            _sut.TotalWithOffers.Should().Be(0);
            _mockDiscounter.Verify(v => v.CalculateDiscount(It.IsAny<IEnumerable<Product>>()), Times.Never);
        }

        [Fact]
        public void ReturnCorrectTotalsWhenOneProductIsScanned()
        {
            _sut.Scan("A99");

            _sut.SubTotal.Should().Be(0.50);
            _sut.TotalWithOffers.Should().Be(0.50);
            _mockDiscounter.Verify(v => v.CalculateDiscount(It.IsAny<IEnumerable<Product>>()), Times.Once);
        }

        [Fact]
        public void ReturnCorrectTotalsWhenLowerCaseProductSkuIsScanned()
        {
            _sut.Scan("a99");

            _sut.SubTotal.Should().Be(0.50);
            _sut.TotalWithOffers.Should().Be(0.50);
            _mockDiscounter.Verify(v => v.CalculateDiscount(It.IsAny<IEnumerable<Product>>()), Times.Once);
        }

        [Fact]
        public void ReturnCorrectTotalsWhenMultipleProductAreScanned()
        {
            _sut.Scan("A99");
            _sut.Scan("B15");
            _sut.Scan("C40");

            _sut.SubTotal.Should().Be(1.40);
            _sut.TotalWithOffers.Should().Be(1.40);
            _mockDiscounter.Verify(v => v.CalculateDiscount(It.IsAny<IEnumerable<Product>>()), Times.Exactly(3));
        }

        [Fact]
        public void ReturnCorrectTotalsWhenQualifyingProductsAreScanned()
        {
            GivenDiscountOf(0.20);

            _sut.Scan("A99", 3);

            _sut.SubTotal.Should().Be(1.50);
            _sut.TotalWithOffers.Should().Be(1.3);
            _mockDiscounter.Verify(v => v.CalculateDiscount(It.IsAny<IEnumerable<Product>>()), Times.Once);
        }

        private void GivenDiscountOf(double discount)
        {
            _mockDiscounter.Setup(x => x.CalculateDiscount(It.IsAny<IEnumerable<Product>>()))
                .Returns(discount);
        }
    }
}