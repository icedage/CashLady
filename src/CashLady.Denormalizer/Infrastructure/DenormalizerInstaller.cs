using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.Denormalizer.Infrastructure
{
    public class DenormalizerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            //container.Register(Classes.FromThisAssembly().BasedOn<IConsumer>());

            //var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            //{
            //    var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
            //    {
            //        h.Username("guest");
            //        h.Password("guest");
            //    });

            //    cfg.ReceiveEndpoint("Denormalizer", ec =>
            //    {
            //        ec.UseMessageScope();
            //        ec.LoadFrom(container);
            //    });
            //});

            //busControl.Start();


            //container.Register(Component.For<IBusControl>().Instance(busControl).Named("u"));
         }
    }
}
