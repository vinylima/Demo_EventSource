
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using ProjectName.Shared.Domain.Abstractions;

namespace ProjectName.Shared.Data.Abstractions
{
    public interface IBaseReadRepository<TModel> where TModel : class, IModel
    {
        bool Exists(Guid id);

        bool ExistsWithFind(Guid id);

        Task<TModel> SearchByIdAsync(Guid id);

        Task<IEnumerable<TModel>> GetAllAsync();

        Task<IEnumerable<TModel>> GetAllAsync(int pageIndex, int pageSize);

        Task<IEnumerable<TModel>> FindAsync(Expression<Func<TModel, bool>> predicate);

        Task<IEnumerable<TModel>> FindAsync(Expression<Func<TModel, bool>> predicate, int pageIndex, int pageSize);
    }
}