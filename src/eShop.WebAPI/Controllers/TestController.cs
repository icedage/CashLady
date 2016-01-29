using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MassTransit;
using MassTransit.Log4NetIntegration.Logging;

namespace eShop.WebAPI.Controllers
{
    public class TestController : ApiController
    {
        public IHttpActionResult Get()
        {
            //Log4NetLogger.Use();
            //var bus = Bus.Factory.CreateUsingRabbitMq(x =>
            //x.Host(new Uri("rabbitmq://localhost/"), h => { }));
            //var busHandle = bus.Start();
            //var message = new SomethingHappenedMessage()
            //{
            //    What = "Test",
            //    When = DateTime.Now
            //};
            //bus.Publish<SomethingHappened>(message);

            //busHandle.Stop();

            return Ok("test");
        }
    }
}
