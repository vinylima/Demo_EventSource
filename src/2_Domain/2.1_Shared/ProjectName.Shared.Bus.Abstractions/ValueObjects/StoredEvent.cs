
using System;

using ProjectName.Shared.Bus.Abstractions.Enums;

namespace ProjectName.Shared.Bus.Abstractions.ValueObjects
{
    public class StoredEvent
    {
        public Guid StoredEventId { get; private set; }
        public EventType EventType { get; private set; }
        public DateTime Time { get; private set; }
        public string Data { get; private set; }

        public StoredEvent(Event @event, string serializedEvent)
        {
            this.StoredEventId = Guid.NewGuid();
            this.Time = @event.Time;
            this.EventType = @event.EventType;
            this.Data = serializedEvent;
        }
    }
}