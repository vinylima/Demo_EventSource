
using System;
using System.Collections.Generic;

using ProjectName.Shared.Bus.Abstractions.ValueObjects;
using ProjectName.Shared.Infra.Server.Data.EventSourcing;

namespace ProjectName.Shared.Infra.Server.Data.Repositories
{
    public class EventStoreRepository : IEventStoreRepository
    {
        public EventStoreRepository()
        {

        }

        public IList<StoredEvent> All(Guid aggregateId)
        {
            throw new NotImplementedException();
        }
        
        public IList<StoredEvent> Find(Predicate<Func<StoredEvent, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Store(StoredEvent theEvent)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}