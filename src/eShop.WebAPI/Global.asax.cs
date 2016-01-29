using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using CashLady.CqrsLib;
using CashLady.CqrsLib.ServiceBus.MassTransit;
using CashLady.Domain.Version1.Commands;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using eShop.WebAPI.Infrastructure;
using MassTransit;

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

          //  container.Install(FromAssembly.This());
            GlobalConfiguration.Configuration.DependencyResolver = new WindsorHttpDependencyResolver(container.Kernel);

            // container.Register(FromAssembly.This().BasedOn<IConsumer>());

            //Bus.Factory.CreateUsingRabbitMq(cfg =>
            //{
            //    var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
            //    {
            //        h.Username("guest");
            //        h.Password("guest");
            //    });

            //    cfg.ReceiveEndpoint("TestPublisher", ec =>
            //    {
            //        ec.UseMessageScope();
            //        ec.LoadFrom(container);
            //    });
            //});


            //// busControl.Start();


            ////container.Register(
            ////    Classes.FromAssemblyNamed("")
            ////        .BasedOn<IBus>()
            ////        .LifestyleTransient()
            ////        .Configure(
            ////            component => component.Instance(busControl)));


            //container.Register(
            //   Classes.FromAssemblyNamed("cashLady.CqrsLib.ServiceBus.MassTransit")
            //       .BasedOn<IBusControl>()
            //       .LifestyleTransient()
            //       .Configure(
            //           component => component.Instance(

            container.Register(AllTypes.FromAssemblyNamed("CashLady.Services").BasedOn<IConsumer>());

            container.Register(
               Component.For<ICommandSender>()
                        .ImplementedBy<MassTransitServiceBus>()
                        .LifeStyle.Transient);

            var busControl= Bus.Factory.CreateUsingRabbitMq(cfg =>
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

           // container.Register(Component.For<IBus>().Instance(busControl));
            container.Register(Component.For<IBusControl>().Instance(busControl));
            // )));

            //var message = new SomethingHappenedMessage()
            //{
            //    What = "Test",
            //    When = DateTime.Now
            //};

            //busControl.Publish<SomethingHappenedMessage>(message);

            //
            
            ////container.Register(Component.For<IServiceBus>().Instance(serviceBus));

            //var bus = Bus.Factory.CreateUsingRabbitMq(x =>
            //{
            //    var host = x.Host(new Uri("rabbitmq://localhost/"), h => { });

            //    x.ReceiveEndpoint(host, "MtPubSubExample_TestSubscriber", e =>
            //      e.Consumer<SomethingHappenedConsumer>());
            //});


            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }

    //public interface SomethingHappened
    //{
    //    string What { get; }
    //    DateTime When { get; }
    //}

    //public class SomethingHappenedMessage : SomethingHappened
    //{
    //    public string What { get; set; }
    //    public DateTime When { get; set; }
    //}

    //public class SomethingHappenedConsumer : IConsumer<ApplyForLoan>
    //{
    //    public Task Consume(ConsumeContext<ApplyForLoan> context)
    //    {
    //        //Console.Write("  TXT: " + context.Message.What);
    //        //Console.Write("  SENT: " + context.Message.When);
    //        //Console.Write("  PROCESSED: " + DateTime.Now);
    //        //Console.WriteLine(" (" + System.Threading.Thread.CurrentThread.ManagedThreadId + ")");
    //        return Task.FromResult(0);
    //    }
    //}


}
