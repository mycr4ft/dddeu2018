﻿using Acme.Commands;
using Acme.Events;
using Acme.Tests.FakeData;
using Xunit;

namespace Acme.Tests
{
    public class StartShoppingTests {

        [Fact]
        public void CustomerStartedShopping()
        {
            var startTime = "";

            new Scenario()
                .When(new StartShopping(Data.HappyCartId,Data.HappyCustomerId,startTime))
                .Then(new CustomerStartedShopping(Data.HappyCartId, Data.HappyCustomerId))
                .Assert();
        }

        [Fact]
        public void CustomerStartedShoppingTwice()
        {
            var startTime = "";

            new Scenario()
                .Given(new CustomerStartedShopping(Data.HappyCartId, Data.HappyCustomerId))
                .When(new StartShopping(Data.HappyCartId, Data.HappyCustomerId, startTime))
                .ThenNothing()
                .Assert();
        }
    }
}