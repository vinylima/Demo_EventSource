
using System;

using MediatR;

using ProjectName.Shared.Bus.Abstractions.Enums;

namespace ProjectName.Shared.Bus.Abstractions
{
    public interface IEvent : INotification
    {
        Guid EventId { get; }

        EventType EventType { get; }

        EventExecutionMode ExecutionMode { get; }

        EventStoreMode StoreMode { get; }
    }
}