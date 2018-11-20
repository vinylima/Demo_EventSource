
using System;

using ProjectName.DomainName.Application.ViewModels;
using ProjectName.Shared.Bus.Abstractions.ValueObjects;

namespace ProjectName.DomainName.Application.Commands.AddressCommands
{
    public class SearchAddressCommand : Command<AddressViewModel>
    {
        public SearchAddressCommand(Guid addressId)
            : base(addressId)
        {

        }
    }
}