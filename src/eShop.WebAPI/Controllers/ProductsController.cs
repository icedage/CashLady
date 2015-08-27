using eShop.Infrastructure;
using eShop.UserRegistry.CommandStack.Commands;
using eShop.WebAPI.Models;
using System;
using System.Web.Http;

namespace eShop.WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        public IBus Bus { get; private set; }
        public IRepository Repository { get; private set; }
        public IEventStore EventStore { get; private set; }

        public ProductsController(IBus bus, IRepository repository, IEventStore eventStore)
        {
            if (bus == null)
            {
                throw new ArgumentNullException("bus");
            }
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            if (eventStore == null)
            {
                throw new ArgumentNullException("eventStore");
            }

            this.Bus = bus;
            this.Repository = repository;
            this.EventStore = eventStore;
        }

        [HttpPost]
        public IHttpActionResult Post(ProductRequest request)
        {
            var command = new RegisterProductCommand() { ProductId = request.ProductId,
                                                         Description = request.Description,
                                                         Location = request.PhotoLocation,
                                                         Price=request.Price,
                                                         ProductName= request.ProductName
                                                       };
            Bus.Send(command);
            return Ok();
        }
    }
}
