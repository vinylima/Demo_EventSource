
using System;
using System.Threading.Tasks;

using MediatR;

using ProjectName.Shared.Bus.Abstractions;
using ProjectName.Shared.Bus.Abstractions.Enums;

namespace ProjectName.Shared.Bus.Core
{
    public class ServiceBus : IServiceBus
    {
        private readonly IMediator _mediator;
        private readonly IEventStore eventStore;

        public ServiceBus(IServiceProvider serviceProvider)
        {
            this._mediator = serviceProvider.GetService<IMediator>();
            this.eventStore = serviceProvider.GetService<IEventStore>();
        }

        public async Task PublishEvent(IEvent @event)
        {
            Task eventRunning;
            
            if (@event.EventType != EventType.Domain_Notification)
                await this.eventStore.Queue(this.eventStore.Store(@event));
            
            eventRunning = Task.Run(() => this._mediator.Publish(@event));
            
            if (@event.ExecutionMode == EventExecutionMode.WaitToClose)
                await eventRunning;
            else
                await this.eventStore.Queue(eventRunning);
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