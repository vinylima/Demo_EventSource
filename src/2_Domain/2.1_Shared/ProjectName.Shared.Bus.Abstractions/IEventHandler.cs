
using MediatR;

using ProjectName.Shared.Bus.Abstractions.ValueObjects;

namespace ProjectName.Shared.Bus.Abstractions
{
    public interface IEventHandler<TEvent> : INotificationHandler<TEvent> where TEvent : Event
    {

    }
}