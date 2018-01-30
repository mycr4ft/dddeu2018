using Acme.Commands;
using Acme.Events;
using Xunit;

namespace Acme.Tests
{
    public class SpecialCaseTests
    {
        [Fact]
        public void SomethingRemovedFromCartOrderEmpty()
        {
            var cartId = "";
            var customerId = "";
            var productId = "";

            new Scenario()
                .Given(new ProductWasRemovedFromCart(customerId, cartId, productId))
                .When(new PlaceOrder(customerId, cartId))
                .ThenNothing()
                .Assert();
        }
    }
}