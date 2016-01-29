using System;
using System.Collections.Generic;

namespace CashLady.CqrsLib
{
    public interface IEventStore
    {
        void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion);

        IEnumerable<Event> GetEventsForAggregate(Guid aggregateId);

        IEnumerable<Event> GetEventsForReplay(DateTime replayFrom);
    }
}
