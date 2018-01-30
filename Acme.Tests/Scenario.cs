using System;
using Acme.Commands;
using Acme.Events;

namespace Acme.Tests
{
    public class Scenario
    {
        public Scenario Given(Event anEvent)
        {
            return this;
        }

        public Scenario When(Command aCommand)
        {
            return this;
        }

        public Scenario Then(Event anEvent)
        {
            return this;
        }

        public void Assert()
        {
            throw new NotImplementedException();
        }
    }
}
