using System;

namespace Acme.Tests.FakeData
{
    public static class Data
    {
        public static string HappyCustomerId = "Thomas";
        public static string GrumpyCustomerId = "Guido";

        public static string HappyOrdId = "Happy order";

        public static string BuildHappyCartId()
        {
            return $"HappyCart-{Guid.NewGuid()}";
        }
    }
}