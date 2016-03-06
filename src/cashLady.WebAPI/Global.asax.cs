using System;
using System.Web.Http;
using CashLady.CqrsLib;
using CashLady.CqrsLib.ServiceBus.MassTransit;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using eShop.WebAPI.Infrastructure;
using MassTransit;
using CashLady.Services.Domain.User;
using CashLady.Services.Domain.Loan;
using CashLady.CqrsLib.EventStore.NEventStore;
using CashLady.Denormalizer.MongoDB.MongoRepository;
using CashLady.Denormalizer.MongoDB.Repositories;

namespace eShop.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new WindsorContainer();
            container.Register(Classes.FromThisAssembly()
            .Pick().If(t => t.Name.EndsWith("Controller"))
            .Configure(configurer => configurer.Named(configurer.Implementation.Name))
            .LifestylePerWebRequest());

            GlobalConfiguration.Configuration.DependencyResolver = new WindsorHttpDependencyResolver(container.Kernel);
           
            container.Register(Types.FromAssemblyNamed("CashLady.Services").BasedOn<IConsumer>());

            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
             {
                 var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                 {
                     h.Username("guest");
                     h.Password("guest");
                 });

                 cfg.ReceiveEndpoint("TestPublisher", ec =>
                 {
                     ec.UseMessageScope();
                     ec.LoadFrom(container);
                 });
             });

            busControl.Start();

            container.Register(Component.For<IBusControl>().Instance(busControl));

            container.Register(
            Component.For<IEventPublisher>().ImplementedBy<MassTransitServiceBus>().Named("EventPublisher")
             .DependsOn(busControl));


            container.Register(
               Component.For<ICommandSender>()
                        .ImplementedBy<MassTransitServiceBus>().Named("CommandSender")
                        .LifeStyle.Transient);

      
            //container.Register(
            //   Component.For<IEventStore>()
            //            .ImplementedBy<CashLady.CqrsLib.EventStore.InMemory.EventStore>()
            //            .LifeStyle.Transient);



            //var store = Wireup.Init()
            //    .LogToOutputWindow()
            //    .UsingInMemoryPersistence()
            //    .UsingSqlPersistence("EventStore") // Connection string is in app.config
            //        .WithDialect(new MsSqlDialect())
            //        .InitializeStorageEngine()
            //        .UsingJsonSerialization()
            //    .Build();

            //container.Register(
            //   Component.For<IEventStore>()
            //            .ImplementedBy<CashLady.CqrsLib.EventStore.NEventStore.EventStore>().DependsOn(store)
            //            .LifeStyle.Transient);

            //container.Register(
            // Component.For<IEventStore>()
            //          .ImplementedBy<CashLady.CqrsLib.EventStore.NEventStore.EventStore>().DependsOn(store)
            //          .LifeStyle.Transient);

            var store = EventStoreFactory.CreateSqlEventStore("EventStoreSQLDatabase");


            //container.Register(
            //   Component.For<IEventStore>()
            //            .ImplementedBy<CashLady.CqrsLib.EventStore.NEventStore.EventStore>().DependsOn(store)
            //            .LifeStyle.Transient);

            //var eventStore = container.Resolve<IEventStore>(store);

            container.Register(Component.For<IEventStore>().Instance(store));


            var eventStore = container.Resolve<IEventStore>();

            container.Register(
            Component.For<IRepository<LoanAggregate>>()
                     .ImplementedBy<Repository<LoanAggregate>>().DependsOn(eventStore)
                     .LifeStyle.Transient);

            container.Register(
      Component.For<IRepository<UserAggregate>>()
               .ImplementedBy<Repository<UserAggregate>>().DependsOn(eventStore)
               .LifeStyle.Transient);


        //    MongoContextProvider contextProvider = new MongoContextProvider("MongoDBconnection", "LoansViewRepository");



        //    container.Register(
        //    Component.For<ILoansViewRepository>()
        //             .ImplementedBy<LoansViewRepository>().DependsOn(contextProvider)
        //             .LifeStyle.Transient);

        //    container.Register(
        //Component.For<IUserViewRepository>()
        //         .ImplementedBy<UserViewRepository>().DependsOn(contextProvider)
        //         .LifeStyle.Transient);


            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
 }
