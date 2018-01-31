using Acme.Commands;
using Acme.Events;
using Acme.Tests.FakeData;
using Xunit;

namespace Acme.Tests
{
    public class PlaceOrderOnCart
    {
        [Fact]
        public void PlaceOrderOnExistingCart()
        {
            new Scenario("PlaceOrderOnExistingCart")
                .When(new PlaceOrder(Data.HappyCustomerId, Data.HappyCartId))
                .Then(new CustomerPlacedOrder(Data.HappyCustomerId, Data.HappyOrdId))
                .Assert();
        }

        [Fact]
        public void PlaceOrderOnAbandonedCart()
        {
            new Scenario("PlaceOrderOnAbandonedCart")
                .Given(new CustomerAbandonedCart(Data.HappyCustomerId, Data.HappyCartId))
                .When(new PlaceOrder(Data.HappyCustomerId, Data.HappyCartId))
                .ThenNothing()
                .Assert();
        }
    }
    
}
