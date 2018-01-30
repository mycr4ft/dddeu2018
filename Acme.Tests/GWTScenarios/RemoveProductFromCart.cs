using Acme.Commands;
using Acme.Events;
using Xunit;

namespace Acme.Tests
{
    public class RemoveProductFromCartTests {

        [Fact]
        public void NothingCouldBeRemovedFromCard()
        {
            var cartId = "";
            var customerId = "";
            var productId = "";

            new Scenario()
                .When(new RemoveProductFromCart(customerId, cartId, productId))
                .ThenNothing()
                .Assert();
        }
        
        [Fact]
        public void OneThingRemovedFromCart()
        {
            var cartId = "";
            var customerId = "";
            var productId = "";

            new Scenario()
                .Given(new ProductWasAddedToCart(customerId, cartId, productId))
                .When(new RemoveProductFromCart(customerId, cartId, productId))
                .Then(new ProductWasRemovedFromCart(customerId, cartId, productId))
                .Assert();
        }
    }
}