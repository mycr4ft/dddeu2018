﻿using Acme.Commands;
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
            string orderId= "";

            new Scenario()
                .When(new PlaceOrder(Data.HappyCustomerId, Data.HappyCartId))
                .Then(new CustomerPlacedOrder(Data.HappyCustomerId, orderId))
                .Assert();
        }

        [Fact]
        public void PlaceOrderOnAbandonedCart()
        {
            new Scenario()
                .Given(new CustomerAbandonedCart(Data.HappyCustomerId, Data.HappyCartId))
                .When(new PlaceOrder(Data.HappyCustomerId, Data.HappyCartId))
                .ThenNothing()
                .Assert();
        }
    }
    
}