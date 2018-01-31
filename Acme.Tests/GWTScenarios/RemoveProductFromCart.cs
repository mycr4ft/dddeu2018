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
            var cartId = Data.BuildHappyCartId();

            new Scenario(EventStore, "NothingCouldBeRemovedFromCard")
                .When(new RemoveProductFromCart(Data.HappyCustomerId, cartId, productId))
                .ThenNothing()
                .Assert();
        }
        
        [Test]
        public void OneThingRemovedFromCart()
        {
            var productId = "";
            var cartId = Data.BuildHappyCartId();

            new Scenario(EventStore, "OneThingRemovedFromCart")
                .Given(new ProductWasAddedToCart(Data.HappyCustomerId, cartId, productId))
                .When(new RemoveProductFromCart(Data.HappyCustomerId, cartId, productId))
                .Then(new ProductWasRemovedFromCart(Data.HappyCustomerId, cartId, productId))
                .Assert();
        }
    }
}