using Acme.Commands;
using Acme.Events;
using Acme.Tests.FakeData;
using Xunit;

namespace Acme.Tests
{
    public class StartShoppingTests {

        [Fact]
        public void CustomerStartedShopping()
        {
            var cartId = "";
            var startTime = "";

            new Scenario()
                .When(new StartShopping(cartId,Data.HappyCustomerId,startTime))
                .Then(new CustomerStartedShopping(cartId, Data.HappyCustomerId))
                .Assert();
        }

        [Fact]
        public void CustomerStartedShoppingTwice()
        {
            var cartId = "";
            var startTime = "";

            new Scenario()
                .Given(new CustomerStartedShopping(cartId, Data.HappyCustomerId))
                .When(new StartShopping(cartId, Data.HappyCustomerId, startTime))
                .ThenNothing()
                .Assert();
        }
    }
}