
using System;

using ProjectName.DomainName.Domain.ValueObjects;
using ProjectName.Shared.Abstractions.Domain;

namespace ProjectName.DomainName.Domain.Models
{
    public class Address : BaseModel<Address>
    {
        public string Street { get; set; }
        public City City { get; set; }

        #region Constructors

        public Address()
        {

        }

        public Address(Guid id, string street, string city)
        {
            this.Id = id;
            this.Street = street;
            this.City = new City
            {
                Name = city
            };
        }

        public Address(Guid id, string street, City city)
        {
            this.Id = id;
            this.Street = street;
            this.AssignCity(city);
        }

        public Address(string street, string city)
        {
            this.Street = street;
            this.City = new City
            {
                Name = city
            };
        }

        public Address(string street, City city)
        {
            this.Street = street;
            this.AssignCity(city);
        }

        #endregion

        public override void CopyTo(Address address)
        {
            address.Street = this.Street;
            address.City = this.City;
        }

        protected internal void AssignCity(City city)
        {
            this.City = city;
        }
    }
}