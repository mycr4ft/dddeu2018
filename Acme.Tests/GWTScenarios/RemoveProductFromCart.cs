using Acme.Commands;
using Acme.Events;
using Acme.Tests.FakeData;
using NUnit.Framework;

namespace Acme.Tests
{
    [TestFixture]
    public class RemoveProductFromCartTests : SetupTests {
        private EventStore _eventStore;

        [SetUp]
        public void SetUp()
        {
            _eventStore = SetupTests.EventStoreCreator();
        }

        [Test]
        public void NothingCouldBeRemovedFromCard()
        {
            var productId = "";

            new Scenario(_eventStore, "NothingCouldBeRemovedFromCard")
                .When(new RemoveProductFromCart(Data.HappyCustomerId, Data.HappyCartId, productId))
                .ThenNothing()
                .Assert();
        }
        
        [Test]
        public void OneThingRemovedFromCart()
        {
            var productId = "";

            new Scenario(_eventStore, "OneThingRemovedFromCart")
                .Given(new ProductWasAddedToCart(Data.HappyCustomerId, Data.HappyCartId, productId))
                .When(new RemoveProductFromCart(Data.HappyCustomerId, Data.HappyCartId, productId))
                .Then(new ProductWasRemovedFromCart(Data.HappyCustomerId, Data.HappyCartId, productId))
                .Assert();
        }
    }
}