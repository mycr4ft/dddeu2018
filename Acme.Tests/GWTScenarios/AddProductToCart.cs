using Acme.Commands;
using Acme.Events;
using Acme.Tests.FakeData;
using NUnit.Framework;

namespace Acme.Tests
{
    [TestFixture]
    public class AddProductToCartTest: SetupTests
    {
        [Test]
        public void FirstProductWasAddedToCart()
        {
            var startTime = "";
            var sku = "";
            var productId = "";
            var cartId = Data.BuildHappyCartId();
            new Scenario(EventStore, "FirstProductWasAddedToCart")
                .When(new AddProductToCart(Data.HappyCustomerId, cartId, sku, startTime))
                .Then(new ProductWasAddedToCart(Data.HappyCustomerId, cartId, productId))
                .Assert();
        }
        
        [Test]
        public void MultipleProductsAddedToCart()
        {
            var startTime = "";
            var sku = "";
            var productId = "";
            var cartId = Data.BuildHappyCartId();
            new Scenario(EventStore, "MultipleProductsAddedToCart")
                .Given(new ProductWasAddedToCart(Data.HappyCustomerId, cartId, productId))
                .Given(new ProductWasAddedToCart(Data.HappyCustomerId, cartId, productId))
                .Given(new ProductWasAddedToCart(Data.HappyCustomerId, cartId, productId))
                .When(new AddProductToCart(Data.HappyCustomerId, cartId, sku, startTime))
                .Then(new ProductWasAddedToCart(Data.HappyCustomerId, cartId, productId))
                .Assert();
        }
    }
}