using Acme.Commands;
using Acme.Events;
using Xunit;

namespace Acme.Tests
{
    public class StartShoppingTests {

        [Fact]
        public void CustomerStartedShopping()
        {
            var cartId = "";
            var customerId = "";
            var startTime = "";

            new Scenario()
                .When(new StartShopping(cartId,customerId,startTime))
                .Then(new CustomerStartedShopping(cartId, customerId))
                .Assert();
        }

        public void CustomerStartedShoppingTwice()
        {
   
        }

    }
}