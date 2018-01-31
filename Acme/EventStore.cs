using System;
using System.Collections.Generic;
using System.Linq;
using Acme.Events;

namespace Acme
{
    public interface EventStore
    {
        void Add(string streamId, IReadOnlyList<Event> events);

        IReadOnlyList<Event> ReadStream(string streamId);
    }

    public class InMemoryEventStore : EventStore
    {
        private Dictionary<string, IList<Event>> _store;

        public InMemoryEventStore()
        {
            _store = new Dictionary<string, IList<Event>>();
        } 
        
        public void Add(string streamId, IReadOnlyList<Event> events)
        {
            
            if (_store.ContainsKey(streamId))
            {
                _store[streamId].Concat(events.ToList());
            }
            else
            {
                _store.Add(streamId, events.ToList());
            }
        }

        public IReadOnlyList<Event> ReadStream(string streamId)
        {
            if (_store.ContainsKey(streamId))
            {
                return _store[streamId].ToList();
            }
            throw new ArgumentException("Stream not found");
        }
    }
}