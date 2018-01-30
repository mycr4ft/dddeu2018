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
            var productId = "";

            new Scenario()
                .When(new RemoveProductFromCart(Data.HappyCustomerId, Data.HappyCartId, productId))
                .ThenNothing()
                .Assert();
        }
        
        [Fact]
        public void OneThingRemovedFromCart()
        {
            var productId = "";

            new Scenario()
                .Given(new ProductWasAddedToCart(Data.HappyCustomerId, Data.HappyCartId, productId))
                .When(new RemoveProductFromCart(Data.HappyCustomerId, Data.HappyCartId, productId))
                .Then(new ProductWasRemovedFromCart(Data.HappyCustomerId, Data.HappyCartId, productId))
                .Assert();
        }
    }
}