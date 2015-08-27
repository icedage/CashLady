using Raven.Client.Embedded;
using Raven.Database.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Indexes;

namespace eShop.Infrastructure.RavenDB
{
    public class RavenDBRepository<T> : IRepository //where T: IAggregate
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

      

        public T GerById<T>(Guid id){
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

        public void Save<T>(T item) where T : IAggregate
        {
            PersistAggregate(item);
        }

        public T GetById<T>(Guid id) where T : IAggregate
        {
            throw new NotImplementedException();
        }

        public T GerById<T, K>(Guid id)
            where T : IAggregate
            where K : AbstractIndexCreationTask, new()
        {
            using (var session = DocumentStore.OpenSession())
            {
                var item = session.Load<T>(id);
                return item;
            }
        }


        public T GetById(Guid id)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var item = session.Load<T>(id);
                return item;
            }
        }
    }
}
