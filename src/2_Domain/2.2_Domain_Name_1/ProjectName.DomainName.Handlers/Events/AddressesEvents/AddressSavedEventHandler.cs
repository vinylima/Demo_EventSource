
using System.Threading;
using System.Threading.Tasks;

using ProjectName.DomainName.Application.Events.AddressesEvents;
using ProjectName.Shared.Bus.Abstractions;

namespace ProjectName.DomainName.Handlers.Events.AddressesEvents
{
    public class AddressSavedEventHandler : IEventHandler<AddressSavedEvent>
    {
        public Task Handle(AddressSavedEvent notification, CancellationToken cancellationToken)
        {
            Thread.Sleep(new System.TimeSpan(0, 0, 30));

            return Task.CompletedTask;
        }
    }
}
