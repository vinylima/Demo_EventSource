
using System;
using System.Threading.Tasks;

using MediatR;

using ProjectName.Shared.Bus.Abstractions;
using ProjectName.Shared.Bus.Abstractions.ValueObjects;

namespace ProjectName.Shared.Bus.Core
{
    public class ServiceBus : IServiceBus
    {
        private readonly IMediator _mediator;

        public ServiceBus(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public async Task PublishEvent(IEvent @event)
        {
            await this._mediator.Publish(@event);
        }
        
        public async Task SendCommand(ICommand command)
        {
            await this._mediator.Send(command);
        }

        public async Task<TResponse> SendCommand<TResponse>(ICommand<TResponse> command)
        {
            TResponse response = await this._mediator.Send(command);
            
            return response;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}