
using ProjectName.DomainName.Domain.ValueObjects;

namespace ProjectName.DomainName.Domain.Models
{
    public static class SearchByCepExtension
    {
        public static void SearchByCep(this Address address, string cep)
        {
            // logic to search cep.
            // you can receive interface parameters to do request cep api

            City city = new City("Belo Horizonte");

            address.AssignCity(city);
        }
    }
}
