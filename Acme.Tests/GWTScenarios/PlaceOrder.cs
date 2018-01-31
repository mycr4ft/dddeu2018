using Acme.Commands;
using Acme.Events;
using Acme.Tests.FakeData;
using NUnit.Framework;

namespace Acme.Tests
{
    [TestFixture]
    public class PlaceOrderOnCart : SetupTests
    {
        private EventStore _eventStore;

        [SetUp]
        public void SetUp()
        {
            _eventStore = SetupTests.EventStoreCreator();
        }
        
        [Test]
        public void PlaceOrderOnExistingCart()
        {
            new Scenario(_eventStore, "PlaceOrderOnExistingCart")
                .When(new PlaceOrder(Data.HappyCustomerId, Data.HappyCartId))
                .Then(new CustomerPlacedOrder(Data.HappyCustomerId, Data.HappyOrdId, Data.HappyCartId))
                .Assert();
        }

        [Test]
        public void PlaceOrderOnAbandonedCart()
        {
            new Scenario(_eventStore, "PlaceOrderOnAbandonedCart")
                .Given(new CustomerAbandonedCart(Data.HappyCustomerId, Data.HappyCartId))
                .When(new PlaceOrder(Data.HappyCustomerId, Data.HappyCartId))
                .ThenNothing()
                .Assert();
        }
    }
    
}
