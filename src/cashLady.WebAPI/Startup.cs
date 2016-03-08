using CashLady.CqrsLib;
using CashLady.CqrsLib.EventStore.NEventStore;
using CashLady.CqrsLib.ServiceBus.MassTransit;
using CashLady.Services.Domain.Loan;
using CashLady.Services.Domain.User;
using CashLady.WebAPI;
using CashLady.WebAPI.Infrastructure;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MassTransit;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;


[assembly: OwinStartup(typeof(CashLady.WebAPI.Startup))]
namespace CashLady.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfig = new HttpConfiguration();
            WebApiConfig.Register(httpConfig);
            ConfigureOAuthTokenConsumption(app);
            ConfigureWebApi(httpConfig);

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


            var store = EventStoreFactory.CreateSqlEventStore("EventStoreSQLDatabase");


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


            app.UseWebApi(httpConfig);

        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();

            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

       

        private void ConfigureOAuthTokenConsumption(IAppBuilder app)
        {
            var issuer = "http://localhost:50644";
            string audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
            byte[] audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["as:AudienceSecret"]);

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audienceId },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)
                    }
                });
        }
    }
}