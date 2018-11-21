
using ProjectName.DomainName.Application.ViewModels;
using ProjectName.Shared.Bus.Abstractions;

namespace ProjectName.DomainName.Application.Commands.AddressCommands
{
    public class AddressCommand : AddressViewModel, ICommand
    {
        protected AddressCommand()
        {

        }

        public AddressCommand(string street)
        {
            this.Street = street;
        }
    }
}