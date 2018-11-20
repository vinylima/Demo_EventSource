
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using ProjectName.Shared.Domain.Abstractions;

namespace ProjectName.Shared.Data.Abstractions
{
    public interface IBaseRepository<TModel> : IBaseReadRepository<TModel> where TModel : class, IModel
    {
        Task<bool> SaveAsync(TModel item);

        Task<bool> SaveRangeAsync(IEnumerable<TModel> collection);

        Task<bool> RemoveAsync(Guid id);

        bool Commit();

        Task<bool> CommitAsync();
    }
}