using Acme.Commands;
using Acme.Events;
using Acme.Tests.FakeData;
using Xunit;

namespace Acme.Tests
{
    public class SpecialCaseTests
    {
        [Fact]
        public void SomethingRemovedFromCartOrderEmpty()
        {
            var cartId = "";
            var productId = "";

            new Scenario()
                .Given(new ProductWasRemovedFromCart(Data.HappyCustomerId, cartId, productId))
                .When(new PlaceOrder(Data.HappyCustomerId, cartId))
                .ThenNothing()
                .Assert();
        }
    }
}