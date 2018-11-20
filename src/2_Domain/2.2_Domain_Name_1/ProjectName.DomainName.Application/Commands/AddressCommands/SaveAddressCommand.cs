
namespace ProjectName.DomainName.Application.Commands.AddressCommands
{
    public class SaveAddressCommand : AddressCommand
    {
        public SaveAddressCommand()
        {

        }

        public SaveAddressCommand(string street)
            : base(street)
        {
            base.Street = street;
        }
    }
}