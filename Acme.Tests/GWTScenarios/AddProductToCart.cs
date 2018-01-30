using Acme.Commands;
using Acme.Events;
using Acme.Tests.FakeData;
using Xunit;

namespace Acme.Tests
{
    public class AddProductToCartTest {

        [Fact]
        public void FirstProductWasAddedToCart()
        {
            var cartId = "";
            var startTime = "";
            var sku = "";
            var productId = "";

            new Scenario()
                .When(new AddProductToCart(Data.HappyCustomerId, cartId, sku, startTime))
                .Then(new ProductWasAddedToCart(Data.HappyCustomerId, cartId, productId))
                .Assert();
        }
        
        [Fact]
        public void MultipleProductsAddedToCart()
        {
            var cartId = "";
            var startTime = "";
            var sku = "";
            var productId = "";

            new Scenario()
                .Given(new ProductWasAddedToCart(Data.HappyCustomerId, cartId, productId))
                .Given(new ProductWasAddedToCart(Data.HappyCustomerId, cartId, productId))
                .Given(new ProductWasAddedToCart(Data.HappyCustomerId, cartId, productId))
                .When(new AddProductToCart(Data.HappyCustomerId, cartId, sku, startTime))
                .Then(new ProductWasAddedToCart(Data.HappyCustomerId, cartId, productId))
                .Assert();
        }
    }
}