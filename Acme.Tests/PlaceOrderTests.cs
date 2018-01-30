using System;
using System.Collections.Generic;
using System.Text;
using Acme.Commands;
using Acme.Events;
using Xunit;

namespace Acme.Tests
{
    public class PlaceOrderTests
    {
        [Fact]
        public void PlaceOrder()
        {
            var custId="";
            string cartId="";
            string orderId= "";

            new Scenario()
                .When(new PlaceOrder(custId, cartId))
                .Then(new CustomerPlacedOrder(custId, orderId))
                .Assert();
        }

        [Fact]
        public void PlaceOrderOnAbandonedCart()
        {
            var custId = "";
            string cartId = "";
            new Scenario()
                .Given(new CustomerAbandonedCart(custId, cartId))
                .When(new PlaceOrder(custId, cartId))
                .ThenNothing()
                .Assert();
        }
    }
    
}
