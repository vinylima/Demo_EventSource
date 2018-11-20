
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using ProjectName.DomainName.Domain.Interfaces.Repository;
using ProjectName.DomainName.Domain.Models;
using ProjectName.DomainName.Infra.Server.Data.Context;

namespace ProjectName.DomainName.Infra.Server.Data.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(DomainName_Context context) 
            : base(context)
        {

        }

        public override async Task<bool> SaveAsync(Address item)
        {
            bool saved, modelExists = false;
            EntityState entityState;

            modelExists = this.Exists(item.Id);

            if (modelExists)
                entityState = EntityState.Modified;
            else
                entityState = EntityState.Added;

            try
            {
                base._db.Attach(item).State = entityState;
                base._db.Attach(item.City).State = entityState;

                if (modelExists)
                    this.Db.Update(item);
                else
                    await this.Db.AddAsync(item);

                saved = true;
            }
            catch(Exception e)
            {
                saved = false;
            }
            
            return saved;
        }

        public override Task<bool> SaveRangeAsync(IEnumerable<Address> collection)
        {
            bool saved = false;
            List<Address> existingModels;
            List<Address> newModels;
            Task addTask = null;

            collection = collection.OrderBy(c => c.Id).ToList();
            
            existingModels = this.Db.AsNoTracking()
                .OrderBy(c => c.Id)
                .Intersect(collection)
                .ToList();
            
            if (existingModels.Count > 0)
                newModels = collection.Except(existingModels).ToList();
            else
                newModels = collection.ToList();
            
            addTask = this.Db.AddRangeAsync(newModels);
            
            existingModels.ForEach(x =>
            {
                this.Db.Attach(x).State = EntityState.Modified;
                this._db.Attach(x.City).State = EntityState.Modified;
            });
            
            addTask?.Wait(-1);
            
            saved = true;
            return Task.FromResult(saved);
        }
    }
}