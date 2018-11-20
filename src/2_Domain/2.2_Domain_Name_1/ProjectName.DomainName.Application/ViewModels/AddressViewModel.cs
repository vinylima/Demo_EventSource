
using System;

using ProjectName.Shared.Abstractions.Application;

namespace ProjectName.DomainName.Application.ViewModels
{
    public class AddressViewModel : BaseViewModel<AddressViewModel>, IViewModel
    {
        public Guid AddressId { get { return this.AggregateId; } set { this.AggregateId = value; } }
        public string Street { get; set; }
        public CityViewModel City { get; set; }
    }
}