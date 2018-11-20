
using System;
using System.Threading.Tasks;

namespace ProjectName.Shared.Bus.Abstractions
{
    public interface IServiceBus : IDisposable
    {
        Task PublishEvent(IEvent @event);

        Task SendCommand(ICommand command);
        
        Task<TResponse> SendCommand<TResponse>(ICommand<TResponse> command);
    }
}