using Acme.Commands;
using Acme.Events;
using Acme.Tests.FakeData;
using NUnit.Framework;
using Xunit;

namespace Acme.Tests
{
    [TestFixture]
    public class StartShopping {

        [Test]
        public void CustomerStartedShopping()
        {
            var startTime = "";

            new Scenario("CustomerStartedShopping")
                .When(new Commands.StartShopping(Data.HappyCartId,Data.HappyCustomerId,startTime))
                .Then(new CustomerStartedShopping(Data.HappyCartId, Data.HappyCustomerId))
                .Assert();
        }

        [Test]
        public void CustomerStartedShoppingTwice()
        {
            var startTime = "";

            new Scenario("CustomerStartedShoppingTwice")
                .Given(new CustomerStartedShopping(Data.HappyCartId, Data.HappyCustomerId))
                .When(new Commands.StartShopping(Data.HappyCartId, Data.HappyCustomerId, startTime))
                .ThenNothing()
                .Assert();
        }
    }
}