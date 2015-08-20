using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure
{
    public interface IAggregate
    {
        Guid Id { get; }

        void ClearUncomittedEvents();

        bool HasPendingChanges { get; }

        IEnumerable<DomainEvent> GetUncommittedEvents();
    }
}
