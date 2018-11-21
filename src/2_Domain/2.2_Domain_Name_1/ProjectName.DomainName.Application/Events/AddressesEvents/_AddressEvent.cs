
using System;

using ProjectName.DomainName.Application.ViewModels;
using ProjectName.Shared.Bus.Abstractions;
using ProjectName.Shared.Bus.Abstractions.Enums;

namespace ProjectName.DomainName.Application.Events.AddressesEvents
{
    public abstract class AddressEvent : AddressViewModel, IEvent
    {
        public Guid EventId { get; set; }

        public EventType EventType { get; }

        public EventExecutionMode ExecutionMode { get; }

        public EventStoreMode StoreMode { get; }

        public AddressEvent(EventType eventType, EventExecutionMode executionMode, EventStoreMode storeMode)
        {
            this.EventId = Guid.NewGuid();

            this.EventType = eventType;
            this.ExecutionMode = executionMode;
            this.StoreMode = storeMode;
        }
    }
}
