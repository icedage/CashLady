using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure
{
    public abstract class Aggregate : IAggregate
    {
        public Guid Id { get; protected set; }

        private IList<DomainEvent> uncommittedEvents = new List<DomainEvent>();

        Guid IAggregate.Id
        {
            get { return Id; }
        }

        public void ClearUncomittedEvents()
        {
            uncommittedEvents.Clear();
        }

        public bool HasPendingChanges
        {
            get { return this.uncommittedEvents.Any(); }
        }

        public IEnumerable<DomainEvent> GetUncommittedEvents()
        {
            return uncommittedEvents.ToArray();
        }

        protected void RaiseEvent(DomainEvent @event)
        {
            uncommittedEvents.Add(@event);
            (this as dynamic).Apply((dynamic)@event);
        }
    }
}
