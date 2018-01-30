using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Acme.Tests
{
    public class ClassGenerator
    {
        private readonly ITestOutputHelper _output;

        public ClassGenerator(ITestOutputHelper output)
        {
            _output = output;
        }
        [Fact]
        public void Generate()
        {
            using (var reader = File.OpenText(@"dsl.json"))
            {
                var o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                
                foreach (var @namespace in o.Properties())
                {
                    var builder = new StringBuilder();
                  
                    builder.AppendLine($"namespace Acme.Messages.{@namespace.Name} {{");

                    foreach (var @class in ((JObject)@namespace.Value).Properties())
                    {
                        builder.AppendLine($"public class {@class.Name} {{");

                        foreach (var property in ((JObject) @class.Value).Properties())
                        {
                            builder.AppendLine($"public {property.Value} {property.Name} {{get;set;}}");
                        }

                        builder.AppendLine("}");
                    }
                    builder.AppendLine("}");

                    File.WriteAllText($"../../../{@namespace.Name}.cs", builder.ToString());
                }
            }
        }
    }
}
