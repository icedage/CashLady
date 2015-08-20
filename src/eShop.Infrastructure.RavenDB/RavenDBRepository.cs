using Raven.Client.Embedded;
using Raven.Database.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.RavenDB
{
    public class RavenDBRepository<T> : IRepository<T> where T: IAggregate
    {
        private static EmbeddableDocumentStore DocumentStore { get; set; }

        static RavenDBRepository()
        {
            NonAdminHttp.EnsureCanListenToWhenInNonAdminContext(8081);
            DocumentStore = new EmbeddableDocumentStore
            {
                ConnectionStringName = "DocumentStore",
                UseEmbeddedHttpServer = true
            };
            DocumentStore.Configuration.Port = 8081;
            //DocumentStore.Conventions.AllowQueriesOnId = true; //Fix this
            DocumentStore.Initialize();
        }

        public IBus Bus { get; private set; }

        public RavenDBRepository(IBus bus)
        {
            if (bus == null)
            {
                throw new ArgumentNullException("bus");
            }
            Bus = bus;
        }

        public void Save<T>(T item)
        {
            PersistAggregate(item);
        }

        public T GetById<T>(Guid id)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var item = session.Load<T>(id);
                return item;
            }
        }

        public T GerById<T, K>(Guid id)
            where K : Raven.Client.Indexes.AbstractIndexCreationTask, new()
        {
            throw new NotImplementedException();
        }

        private void PersistAggregate<T>(T item)
        {
            using (var session = DocumentStore.OpenSession())
            {
                session.Store(item);
                session.SaveChanges();
            }
        }

        private void ManageUncommittedEvents<T>(T item) where T : IAggregate
        {

            item.GetUncommittedEvents()
                .ToList()
                .ForEach(e => Bus.RaiseEvent(e));
            item.ClearUncomittedEvents();
        }
    }
}
