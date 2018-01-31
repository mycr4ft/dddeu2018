using System.Collections.Generic;
using Acme.Events;

namespace Acme
{
    public interface EventStore
    {
        void Add(string streamId, IEnumerable<Event> events);

        IEnumerable<Event> ReadStream(string streamId);
    }
}