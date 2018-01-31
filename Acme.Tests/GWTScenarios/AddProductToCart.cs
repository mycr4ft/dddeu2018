using Acme.Commands;
using Acme.Events;
using Acme.Tests.FakeData;
using NUnit.Framework;

namespace Acme.Tests
{
    [TestFixture]
    public class AddProductToCartTest {

        [Test]
        public void FirstProductWasAddedToCart()
        {
            var startTime = "";
            var sku = "";
            var productId = "";
            new Scenario("FirstProductWasAddedToCart")
                .When(new AddProductToCart(Data.HappyCustomerId, Data.HappyCartId, sku, startTime))
                .Then(new ProductWasAddedToCart(Data.HappyCustomerId, Data.HappyCartId, productId))
                .Assert();
        }
        
        [Test]
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