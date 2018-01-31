using System;
using NUnit.Framework;

namespace Acme.Tests
{
    [TestFixture]
    public class SetupTests
    {
        public EventStore EventStore;

        [OneTimeSetUp]
        public void SetUp()
        {
            EventStore = new InMemoryEventStore();
        }
        
        [OneTimeTearDown]
        public void Cleanup()
        {
            StepsReporter.Instance().Build();
            GenerateStreamHtml.Generate(EventStore);
        }
    }
}