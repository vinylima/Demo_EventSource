
using ProjectName.DomainName.Application.ViewModels;
using ProjectName.Shared.Bus.Abstractions.Enums;

namespace ProjectName.DomainName.Application.Events.AddressesEvents
{
    public class AddressSavedEvent : AddressEvent
    {
        public AddressSavedEvent() 
            : base(EventType.Address_Saved, EventExecutionMode.Queue, EventStoreMode.LocalStore)
        {

        }

        public AddressSavedEvent(string street, string city)
            : base(EventType.Address_Saved, EventExecutionMode.Queue, EventStoreMode.LocalStore)
        {
            this.Street = street;
            this.City = new CityViewModel
            {
                Name = city
            };
        }
    }
}