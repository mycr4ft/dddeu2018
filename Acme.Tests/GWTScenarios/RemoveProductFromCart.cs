using Acme.Commands;
using Acme.Events;
using Acme.Tests.FakeData;
using NUnit.Framework;

namespace Acme.Tests
{
    [TestFixture]
    public class RemoveProductFromCartTests : SetupTests {
        [Test]
        public void NothingCouldBeRemovedFromCard()
        {
            var productId = "";

            new Scenario(EventStore, "NothingCouldBeRemovedFromCard")
                .When(new RemoveProductFromCart(Data.HappyCustomerId, Data.HappyCartId, productId))
                .ThenNothing()
                .Assert();
        }
        
        [Test]
        public void OneThingRemovedFromCart()
        {
            var productId = "";

            new Scenario(EventStore, "OneThingRemovedFromCart")
                .Given(new ProductWasAddedToCart(Data.HappyCustomerId, Data.HappyCartId, productId))
                .When(new RemoveProductFromCart(Data.HappyCustomerId, Data.HappyCartId, productId))
                .Then(new ProductWasRemovedFromCart(Data.HappyCustomerId, Data.HappyCartId, productId))
                .Assert();
        }
    }
}