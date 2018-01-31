using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Acme.Events;
using Newtonsoft.Json;

namespace Acme.Tests
{
    public static class GenerateStreamHtml
    {
        public static void Generate(EventStore eventstore)
        {
            foreach (var streamId in eventstore.GetStreamIds())
            {
                var events = eventstore.ReadStream(streamId);
                GenerateHtml(streamId, events);
            }
        }

        private static void GenerateHtml(string streamId, IReadOnlyList<Event> events)
        {
            var builder = new StringBuilder();

            builder.AppendLine("<Html><Body>");

            builder.AppendLine($"<H1>Events in stream {streamId}</H1>");

            foreach (var @event in events)
            {
                builder.AppendLine($"<pre>{JsonConvert.SerializeObject(@event, Formatting.Indented)}</pre>");
            }

            builder.AppendLine("</Body></Html>");


            File.WriteAllText($"../../../Eventstore/{streamId}.html", builder.ToString());
        }
    }
}
