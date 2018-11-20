
namespace ProjectName.DomainName.Domain.ValueObjects
{
    public class City
    {
        public string Name { get; set; }
        public string IgnoredPropertyInEntity { get; set; }

        public City()
        {

        }

        public City(string name)
        {
            this.Name = name;
        }
    }
}