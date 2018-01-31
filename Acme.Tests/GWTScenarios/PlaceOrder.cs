using Acme.Commands;
using Acme.Events;
using Acme.Tests.FakeData;
using NUnit.Framework;

namespace Acme.Tests
{
    [TestFixture]
    public class PlaceOrderOnCart : SetupTests
    {
        [Test]
        public void PlaceOrderOnExistingCart()
        {
            new Scenario(EventStore, "PlaceOrderOnExistingCart")
                .When(new PlaceOrder(Data.HappyCustomerId, Data.HappyCartId))
                .Then(new CustomerPlacedOrder(Data.HappyCustomerId, Data.HappyOrdId, Data.HappyCartId))
                .Assert();
        }

        [Test]
        public void PlaceOrderOnAbandonedCart()
        {
            new Scenario(EventStore, "PlaceOrderOnAbandonedCart")
                .Given(new CustomerAbandonedCart(Data.HappyCustomerId, Data.HappyCartId))
                .When(new PlaceOrder(Data.HappyCustomerId, Data.HappyCartId))
                .ThenNothing()
                .Assert();
        }
    }
    
}
