using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.CqrsLib
{
    public class Repository<T> : IRepository<T> where T : AggregateRoot, new()
    {
        private readonly IEventStore _storage;
        private readonly Func<T> factoryMethod;

        public Repository(IEventStore storage)
        {
            _storage = storage;
        }

        public Repository(IEventStore storage, Func<T> factoryMethod)
        {
            _storage = storage;
            this.factoryMethod = factoryMethod;
        }

        public void Save(AggregateRoot aggregate)
        {
            _storage.SaveEvents(aggregate.Id, aggregate.GetUncommittedChanges(), aggregate.Version);
        }

        public T GetById(Guid id)
        {
            T obj;// = new T();//lots of ways to do this

            if (factoryMethod != null)
            {
                obj = factoryMethod();
            }
            else
            {
                obj = new T();
            }

            var e = _storage.GetEventsForAggregate(id).ToList();
            obj.LoadsFromHistory(e);
            return obj;
        }
    }
}
