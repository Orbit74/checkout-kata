using checkout_kata.test.Stubs;
using FluentAssertions;
using Xunit;

namespace checkout_kata.test
{
    public class CheckoutShould
    {
        private readonly Checkout _sut;

        public CheckoutShould()
        {
            _sut = new Checkout(new ProductCatalogueStub());
        }

        [Fact]
        public void ReturnZeroTotalWhenNoProductsScanned()
        {
            _sut.GetTotal().Should().Be(0);
        }
    }
}