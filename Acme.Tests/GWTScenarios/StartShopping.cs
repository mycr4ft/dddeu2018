using Acme.Commands;
using Acme.Events;
using Acme.Tests.FakeData;
using NUnit.Framework;
using Xunit;

namespace Acme.Tests
{
    [TestFixture]
    public class StartShopping : SetupTests {
        [Test]
        public void CustomerStartedShopping()
        {
            var startTime = "";
            var cartId = Data.BuildHappyCartId();

            new Scenario(EventStore, "CustomerStartedShopping")
                .When(new Commands.StartShopping(Data.HappyCustomerId,cartId,startTime))
                .Then(new CustomerStartedShopping(Data.HappyCustomerId, cartId))
                .Assert();
        }

        [Test]
        public void CustomerStartedShoppingTwice()
        {
            var startTime = "";
            var cartId = Data.BuildHappyCartId();

            new Scenario(EventStore, "CustomerStartedShoppingTwice")
                .Given(new CustomerStartedShopping(Data.HappyCustomerId, cartId))
                .When(new Commands.StartShopping(Data.HappyCustomerId, cartId, startTime))
                .ThenNothing()
                .Assert();
        }
    }
}