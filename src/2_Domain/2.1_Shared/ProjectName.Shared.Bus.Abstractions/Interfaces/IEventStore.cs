
using System;
using System.Threading.Tasks;

namespace ProjectName.Shared.Bus.Abstractions
{
    public interface IEventStore : IDisposable
    {
        Task<bool> Store(IEvent @event);

        Task Queue(Task task);
    }
}