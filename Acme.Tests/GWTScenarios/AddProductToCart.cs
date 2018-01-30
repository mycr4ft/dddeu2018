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
            var startTime = "";
            var sku = "";
            var productId = "";

            new Scenario()
                .When(new AddProductToCart(Data.HappyCustomerId, Data.HappyCartId, sku, startTime))
                .Then(new ProductWasAddedToCart(Data.HappyCustomerId, Data.HappyCartId, productId))
                .Assert();
        }
        
        [Fact]
        public void MultipleProductsAddedToCart()
        {
            var startTime = "";
            var sku = "";
            var productId = "";

            new Scenario("MultipleProductsAddedToCart")
                .Given(new ProductWasAddedToCart(Data.HappyCustomerId, Data.HappyCartId, productId))
                .Given(new ProductWasAddedToCart(Data.HappyCustomerId, Data.HappyCartId, productId))
                .Given(new ProductWasAddedToCart(Data.HappyCustomerId, Data.HappyCartId, productId))
                .When(new AddProductToCart(Data.HappyCustomerId, Data.HappyCartId, sku, startTime))
                .Then(new ProductWasAddedToCart(Data.HappyCustomerId, Data.HappyCartId, productId))
                .Assert();
        }
    }
}