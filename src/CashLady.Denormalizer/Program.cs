using CashLady.Denormalizer.MongoDB.MongoRepository;
using CashLady.Denormalizer.MongoDB.Repositories;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MassTransit;
using System;

namespace CashLady.Denormalizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Denormaliser Started");
            var container = new WindsorContainer();
            //container.Register(Classes.FromThisAssembly())

           
            container.Register(Classes.FromThisAssembly().BasedOn<IConsumer>());

            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint("Denormalizer", ec =>
                {
                    ec.UseMessageScope();
                    ec.LoadFrom(container);
                });
            });

            busControl.Start();

            MongoContextProvider contextProvider = new MongoContextProvider("MongoDBconnection", "LoansViewRepository");



            //string connectionStringName, string databaseName
            //   container.Register(
            //Component.For<IMongoContextProvider>()
            //         .ImplementedBy<MongoContextProvider>().DependsOn(Dependency.OnValue("connectionStringName", "MongoDBconnection"), Dependency.OnValue("databaseName", "LoansViewRepository"))
            //         .LifeStyle.Transient);

            //var eventStore = container.Resolve<IMongoContextProvider>();

            container.Register(Component.For<IMongoContextProvider>().Instance(contextProvider));

            container.Register(
            Component.For<ILoansViewRepository>()
                     .ImplementedBy<LoansViewRepository>().DependsOn(container.Resolve<IMongoContextProvider>())
                     .LifeStyle.Transient);

            container.Register(
        Component.For<IUserViewRepository>()
                 .ImplementedBy<UserViewRepository>().DependsOn(container.Resolve<IMongoContextProvider>())
                 .LifeStyle.Transient);


            container.Register(Component.For<IBusControl>().Instance(busControl).Named("u"));
        }

    }
}
