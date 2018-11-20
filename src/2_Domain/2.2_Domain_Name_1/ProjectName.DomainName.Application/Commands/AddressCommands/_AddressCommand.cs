
using ProjectName.DomainName.Application.ViewModels;

namespace ProjectName.DomainName.Application.Commands.AddressCommands
{
    public class AddressCommand : AddressViewModel
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