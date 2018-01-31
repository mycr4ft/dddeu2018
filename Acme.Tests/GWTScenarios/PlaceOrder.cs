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
            var cartId = Data.BuildHappyCartId();
            new Scenario(EventStore, "PlaceOrderOnExistingCart")
                .When(new PlaceOrder(Data.HappyCustomerId, cartId))
                .Then(new CustomerPlacedOrder(Data.HappyCustomerId, Data.HappyOrdId, cartId))
                .Assert();
        }

        [Test]
        public void PlaceOrderOnAbandonedCart()
        {
            var cartId = Data.BuildHappyCartId();
            new Scenario(EventStore, "PlaceOrderOnAbandonedCart")
                .Given(new CustomerAbandonedCart(Data.HappyCustomerId, cartId))
                .When(new PlaceOrder(Data.HappyCustomerId, cartId))
                .ThenNothing()
                .Assert();
        }
    }
    
}
