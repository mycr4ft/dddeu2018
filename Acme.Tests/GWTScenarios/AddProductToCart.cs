using Acme.Commands;
using Acme.Events;
using Xunit;

namespace Acme.Tests
{
    public class AddProductToCartTest {

        [Fact]
        public void FirstProductWasAddedToCart()
        {
            var cartId = "";
            var customerId = "";
            var startTime = "";
            var sku = "";
            var productId = "";

            new Scenario()
                .When(new AddProductToCart(customerId, cartId, sku, startTime))
                .Then(new ProductWasAddedToCart(customerId, cartId, productId))
                .Assert();
        }
        
        [Fact]
        public void MultipleProductsAddedToCart()
        {
            var cartId = "";
            var customerId = "";
            var startTime = "";
            var sku = "";
            var productId = "";

            new Scenario()
                .Given(new ProductWasAddedToCart(customerId, cartId, productId))
                .Given(new ProductWasAddedToCart(customerId, cartId, productId))
                .Given(new ProductWasAddedToCart(customerId, cartId, productId))
                .When(new AddProductToCart(customerId, cartId, sku, startTime))
                .Then(new ProductWasAddedToCart(customerId, cartId, productId))
                .Assert();
        }
    }
}