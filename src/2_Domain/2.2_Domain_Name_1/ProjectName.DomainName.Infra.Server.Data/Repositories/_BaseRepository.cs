
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using ProjectName.DomainName.Infra.Server.Data.Context;
using ProjectName.Shared.Abstractions.Data;
using ProjectName.Shared.Abstractions.Domain;

namespace ProjectName.DomainName.Infra.Server.Data.Repositories
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : BaseModel<TModel>, IModel
    {
        protected readonly DbSet<TModel> Db;
        protected readonly DomainName_Context _db;

        public BaseRepository(DomainName_Context context)
        {
            context.ChangeTracker.LazyLoadingEnabled = false;
            
            this._db = context;
            this.Db = context.Set<TModel>();
        }

        public bool Exists(Guid id)
        {
            bool exists = false;
            TModel item;

            item = this.Db.Where(x => x.Id == id)
                .FirstOrDefaultAsync()
                .GetAwaiter()
                .GetResult();
            
            exists = item != null;

            item?.Dispose();
            item = null;

            return exists;
        }

        public bool ExistsWithFind(Guid id)
        {
            bool exists = false;
            TModel item;

            item = this.Db.FindAsync(id)
                .GetAwaiter()
                .GetResult();

            exists = item != null;

            item?.Dispose();
            item = null;

            return exists;
        }

        public Task<TModel> SearchByIdAsync(Guid id)
        {
            TModel item = null;

            try
            {
                item = this.Db.Where(e => e.Id.Equals(id))
                    .AsNoTracking()
                    .FirstOrDefault();
            }
            catch(Exception e)
            {

            }

            return Task.FromResult(item);
        }
        
        private Task<TModel> SearchByIdAsync(Guid id, bool track = true)
        {
            TModel item = null;
            IQueryable<TModel> query;
            try
            {
                query = this.Db.Where(e => e.Id.Equals(id));

                if (!track)
                    query = query.AsNoTracking();

                item = query.FirstOrDefault();

                GC.SuppressFinalize(query);
            }
            catch (Exception e)
            {

            }

            return Task.FromResult(item);
        }

        public Task<IEnumerable<TModel>> FindAsync(Expression<Func<TModel, bool>> predicate)
        {
            IEnumerable<TModel> collection;

            try
            {
                collection = this.Db.Where(predicate)
                    .AsNoTracking()
                    .AsEnumerable();
            }
            catch(Exception e)
            {
                collection = new List<TModel>();
            }

            return Task.FromResult(collection);
        }

        public Task<IEnumerable<TModel>> FindAsync(Expression<Func<TModel, bool>> predicate, int pageIndex, int pageSize)
        {
            IEnumerable<TModel> collection = null;

            try
            {
                collection = this.Db.Where(predicate)
                    .Skip(pageIndex)
                    .Take(pageSize)
                    .AsNoTracking()
                    .AsEnumerable();
            }
            catch (Exception e)
            {

            }

            return Task.FromResult(collection);
        }

        public Task<IEnumerable<TModel>> GetAllAsync()
        {
            IEnumerable<TModel> collection;

            try
            {
                collection = this.Db.AsNoTracking()
                    .AsEnumerable();
            }
            catch (Exception e)
            {
                collection = new List<TModel>();
            }

            return Task.FromResult(collection);
        }

        public Task<IEnumerable<TModel>> GetAllAsync(int pageIndex, int pageSize)
        {
            IEnumerable<TModel> collection = null;

            if (pageIndex < 1 || (pageIndex >= 0 && pageSize < 1))
                return Task.FromResult(new List<TModel>().AsEnumerable());

            try
            {
                collection = this.Db.Skip(pageIndex)
                    .Take(pageSize)
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception e)
            {

            }

            return Task.FromResult(collection);
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            bool removed = false;

            try
            {
                var item = this.Db.Where(i => i.Id == id)
                    .AsNoTracking()
                    .FirstOrDefault();

                if (item == null)
                    return Task.FromResult(false);
                
                this.Db.Remove(item);

                item?.Dispose();

                removed = true;
            }
            catch(Exception e)
            {
                removed = false;
            }

            return Task.FromResult(removed);
        }

        public virtual async Task<bool> SaveAsync(TModel item)
        {
            bool saved = false;

            try
            {
                if (!this.Exists(item.Id))
                {
                    await this.Db.AddAsync(item);
                    return true;
                }
                
                this.Db.Attach(item).State = EntityState.Modified;
                this.Db.Update(item);

                saved = true;
            }
            catch(Exception e)
            {
                
            }

            return saved;
        }

        public virtual Task<bool> SaveRangeAsync(IEnumerable<TModel> collection)
        {
            bool saved = false;
            List<TModel> existingModels;
            List<TModel> newModels;
            Task addTask = null;

            try
            {
                existingModels = this.Db.Except(collection).ToList();
                
                if (existingModels.Count() > 0)
                    newModels = existingModels.Except(collection).ToList();
                else
                    newModels = collection.ToList();
                
                addTask = this.Db.AddRangeAsync(newModels);
                
                if (existingModels.Count() > 0)
                {
                    newModels.ForEach(i =>
                    {
                        this.Db.Attach(i).State = EntityState.Modified;
                    });

                    this.Db.UpdateRange(existingModels);
                }

                addTask?.Wait(-1);

                saved = true;
            }
            catch(Exception e)
            {
                saved = false;
            }
            

            return Task.FromResult(saved);
        }

        public bool Commit()
        {
            bool commited;

            try
            {
                commited = this._db.SaveChanges() > 0;
            }
            catch(Exception e)
            {
                commited = false;
            }
            
            return commited;
        }

        public async Task<bool> CommitAsync()
        {
            int rowsAffecteds = 0;

            try
            {
                rowsAffecteds = await this._db.SaveChangesAsync();
            }
            catch(Exception e)
            {
                
            }
            
            return rowsAffecteds > 0;
        }
    }
}