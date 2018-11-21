
using System;
using System.Threading;
using System.Threading.Tasks;

using ProjectName.DomainName.Application.Commands.AddressCommands;
using ProjectName.DomainName.Application.Events.AddressesEvents;
using ProjectName.DomainName.Domain.Interfaces.Repository;
using ProjectName.DomainName.Domain.Models;
using ProjectName.DomainName.Domain.ValueObjects;
using ProjectName.Shared.Bus.Abstractions;

namespace ProjectName.DomainName.Handlers.Addresses
{
    public class SaveAddressCommandHandler : ICommandHandler<SaveAddressCommand>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly INotificationStore _notificationStore;
        private readonly IServiceBus _serviceBus;

        public SaveAddressCommandHandler(IServiceProvider serviceProvider)
        {
            this._addressRepository = serviceProvider.GetService<IAddressRepository>();
            this._notificationStore = serviceProvider.GetService<INotificationStore>();
            this._serviceBus = serviceProvider.GetService<IServiceBus>();
        }

        public async Task<bool> Handle(SaveAddressCommand request, CancellationToken cancellationToken)
        {
            bool executed = true;
            Address address;

            address = new Address(request.AddressId, request.Street, request.City.Name);

            /*
            City city = new City(request.City.Name);
            address = new Address(request.AddressId, request.Street, city);
            */

            await this._addressRepository.SaveAsync(address);

            if (!this._notificationStore.HasNotifications())
            {
                await this._addressRepository.CommitAsync();
                await this._serviceBus.PublishEvent(new AddressSavedEvent(request.Street, request.City.Name));
            }

            return executed;
        }
    }
}