using Acme.Commands;
using Acme.Events;
using Acme.Tests.FakeData;
using Xunit;

namespace Acme.Tests
{
    public class RemoveProductFromCartTests {

        [Fact]
        public void NothingCouldBeRemovedFromCard()
        {
            var cartId = "";
            var productId = "";

            new Scenario()
                .When(new RemoveProductFromCart(Data.HappyCustomerId, cartId, productId))
                .ThenNothing()
                .Assert();
        }
        
        [Fact]
        public void OneThingRemovedFromCart()
        {
            var cartId = "";
            var productId = "";

            new Scenario()
                .Given(new ProductWasAddedToCart(Data.HappyCustomerId, cartId, productId))
                .When(new RemoveProductFromCart(Data.HappyCustomerId, cartId, productId))
                .Then(new ProductWasRemovedFromCart(Data.HappyCustomerId, cartId, productId))
                .Assert();
        }
    }
}