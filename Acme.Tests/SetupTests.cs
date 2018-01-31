using System;
using NUnit.Framework;

namespace Acme.Tests
{
    [TestFixture]
    public class SetupTests
    {
        [OneTimeSetUp]
        public void Init()
        {
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            StepsReporter.Instance().Build();
        }

        [Test]
        public void Add()
        {
            /* ... */
        }
    }
}