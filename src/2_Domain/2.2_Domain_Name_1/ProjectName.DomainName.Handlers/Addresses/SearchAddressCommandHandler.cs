
using System.Threading;
using System.Threading.Tasks;

using ProjectName.DomainName.Application.Commands.AddressCommands;
using ProjectName.DomainName.Application.ViewModels;
using ProjectName.DomainName.Domain.Interfaces.Repository;
using ProjectName.Shared.Bus.Abstractions;

namespace ProjectName.DomainName.Handlers.Addresses
{
    public class SearchAddressCommandHandler : ICommandHandler<SearchAddressCommand, AddressViewModel>
    {
        private readonly IAddressReadRepository _addressReadRepository;

        public SearchAddressCommandHandler(IAddressReadRepository addressReadRepository)
        {
            this._addressReadRepository = addressReadRepository;
        }

        public async Task<AddressViewModel> Handle(SearchAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await this._addressReadRepository.SearchByIdAsync(request.AggregateId);

            return address.ToViewModel();
        }
    }
}
