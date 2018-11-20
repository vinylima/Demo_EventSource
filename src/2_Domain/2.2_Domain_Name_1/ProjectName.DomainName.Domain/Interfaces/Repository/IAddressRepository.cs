
using ProjectName.DomainName.Domain.Models;
using ProjectName.Shared.Abstractions.Data;

namespace ProjectName.DomainName.Domain.Interfaces.Repository
{
    public interface IAddressRepository : IBaseRepository<Address>, IAddressReadRepository
    {

    }
}