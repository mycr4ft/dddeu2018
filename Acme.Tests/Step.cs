using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Tests
{
    public class Step
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public Dictionary<string, string> Data { get; set; }
    }
}
