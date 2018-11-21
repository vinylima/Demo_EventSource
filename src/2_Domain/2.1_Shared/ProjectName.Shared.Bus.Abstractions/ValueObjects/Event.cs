
using System;

using ProjectName.Shared.Bus.Abstractions.Enums;

namespace ProjectName.Shared.Bus.Abstractions.ValueObjects
{
    public abstract class Event : IEvent
    {
        public Guid EventId { get; protected set; }
        public DateTime Time { get; private set; }
        public EventType EventType { get; private set; }
        public EventExecutionMode ExecutionMode { get; private set; }
        public EventStoreMode StoreMode { get; private set; }
        public Type ResourceName { get; protected set; }

        #region Constructors

        protected Event(EventType eventType, EventExecutionMode executionMode, 
            EventStoreMode storeMode)
        {
            this.EventId = Guid.NewGuid();
            this.Time = DateTime.Now;
            this.ResourceName = this.GetType();
            this.EventType = eventType;
            this.ExecutionMode = executionMode;
            this.StoreMode = storeMode;
        }

        protected Event(Guid eventId, EventType eventType, EventExecutionMode executionMode, 
            EventStoreMode storeMode)
        {
            this.EventId = eventId;
            this.Time = DateTime.Now;
            this.ResourceName = this.GetType();
            this.EventType = eventType;
            this.ExecutionMode = executionMode;
            this.StoreMode = storeMode;
        }

        #endregion
    }
}