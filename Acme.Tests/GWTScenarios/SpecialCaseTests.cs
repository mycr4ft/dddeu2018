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
            var productId = "";

            new Scenario()
                .Given(new ProductWasRemovedFromCart(Data.HappyCustomerId, Data.HappyCartId, productId))
                .When(new PlaceOrder(Data.HappyCustomerId, Data.HappyCartId))
                .ThenNothing()
                .Assert();
        }
    }
}