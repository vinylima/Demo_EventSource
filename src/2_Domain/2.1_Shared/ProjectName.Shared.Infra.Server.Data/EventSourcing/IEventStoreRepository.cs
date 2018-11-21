
using System;
using System.Collections.Generic;

using ProjectName.Shared.Bus.Abstractions.ValueObjects;

namespace ProjectName.Shared.Infra.Server.Data.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
        IList<StoredEvent> Find(Predicate<Func<StoredEvent, bool>> predicate);
    }
}