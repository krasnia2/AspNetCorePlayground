using System;

namespace CqrsExample.RequestHandlers
{
    public abstract class EventSourceEvent
    {
        public DateTime Timestamp { get; }
        public string EventType { get; set; }
        private EventSourceEvent() { }

        protected EventSourceEvent(DateTime timestamp, string evenType)
        {
            // Id = Guid.NewGuid();
            Timestamp = timestamp;
            EventType = evenType;
        }
    }
}
