
using ProjectName.DomainName.Domain.Models;

namespace ProjectName.DomainName.Application.ViewModels
{
    public static class CopyToAddressViewModelExtension
    {
        public static AddressViewModel ToViewModel(this Address address)
        {
            return new AddressViewModel
            {
                AddressId = address.Id,
                City = new CityViewModel
                {
                    Name = address.City.Name,
                }
            };
        }
    }
}