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
            _sut.GetTotal().Should().Be(0);
        }

        [Fact]
        public void ReturnZeroTotalWhenInvlidaProductIsScanned()
        {
            _sut.Scan("Invalid");

            _sut.GetTotal().Should().Be(0);
        }

        [Fact]
        public void ReturnCorrectTotalWhenOneProductIsScanned()
        {
            _sut.Scan("A99");

            _sut.GetTotal().Should().Be(0.50);
        }

        [Fact]
        public void ReturnCorrectTotalWhenMultipleProductAreScanned()
        {
            _sut.Scan("A99");
            _sut.Scan("B15");
            _sut.Scan("C40");

            _sut.GetTotal().Should().Be(1.4);
        }

        [Fact]
        public void ReturnDiscountedTotalWhenProductsAreScanned()
        {
            GivenDiscountOf(0.20);

            _sut.Scan("A99");
            _sut.Scan("A99");
            _sut.Scan("A99");

            _sut.GetTotal().Should().Be(1.3);
        }

        private void GivenDiscountOf(double discount)
        {
            _mockDiscounter.Setup(x => x.CalculateDiscount(It.IsAny<IEnumerable<Product>>()))
                .Returns(discount);
        }
    }
}