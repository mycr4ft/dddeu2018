using System;
using NUnit.Framework;

namespace Acme.Tests
{
    [TestFixture]
    public class SetupTests
    {
        public delegate EventStore NewEventStore();

        public static NewEventStore EventStoreCreator;
        
        [OneTimeSetUp]
        public void Init()
        {
            NewEventStore n = new NewEventStore(NewInMemoryEventstore);
            EventStoreCreator = n;
        }

        private EventStore NewInMemoryEventstore()
        {
            return new InMemoryEventStore();
        }
        

        [OneTimeTearDown]
        public void Cleanup()
        {
            StepsReporter.Instance().Build();
        }
    }
}