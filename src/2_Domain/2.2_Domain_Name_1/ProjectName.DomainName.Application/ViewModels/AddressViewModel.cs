
using System;

using ProjectName.Shared.Abstractions.Application;

namespace ProjectName.DomainName.Application.ViewModels
{
    public class AddressViewModel : BaseViewModel<AddressViewModel>, IViewModel
    {
        public Guid AddressId { get; set; }
        public string Street { get; set; }
        public CityViewModel City { get; set; }
    }
}