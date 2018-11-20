
using ProjectName.Shared.Abstractions.Application;

namespace ProjectName.DomainName.Application.ViewModels
{
    public class CityViewModel : BaseViewModel<AddressViewModel>, IViewModel
    {
        public string Name { get; set; }
    }
}