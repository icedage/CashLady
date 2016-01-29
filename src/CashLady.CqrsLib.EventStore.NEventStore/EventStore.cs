using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEventStore;

namespace CashLady.CqrsLib.EventStore.NEventStore
{
    public class EventStore : IEventStore
    {
        private readonly IStoreEvents store;

        public EventStore(IStoreEvents store)
        {
            this.store = store;
        }

        public void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion)
        {
            using (IEventStream stream = store.OpenStream(aggregateId, int.MinValue, int.MaxValue))
            {
                foreach (var @event in events)
                {
                    stream.Add(new EventMessage { Body = @event });
                }

                stream.CommitChanges(Guid.NewGuid());
            }
        }

        public IEnumerable<Event> GetEventsForAggregate(Guid aggregateId)
        {
            using (IEventStream stream = store.OpenStream(aggregateId, int.MinValue, int.MaxValue))
            {
                foreach (var eventMessage in stream.CommittedEvents)
                {
                    yield return (Event)eventMessage.Body;
                }
            }
        }

        public IEnumerable<Event> GetEventsForReplay(DateTime replayFrom)
        {
            var commits = this.store.Advanced.GetFrom("default", replayFrom).OrderBy(x => x.CommitStamp);

            foreach (var commit in commits)
            {
                foreach (EventMessage eventMessage in commit.Events)
                {
                    yield return (Event)eventMessage.Body;
                }
            }
        }
    }
}
