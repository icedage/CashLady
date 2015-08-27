using eShop.Infrastructure;
using eShop.UserRegistry.CommandStack.Commands;
using eShop.UserRegistry.CommandStack.Domain;

namespace eShop.UserRegistry.CommandStack.Sagas
{
    public class ProductSaga : Saga,
        IHandleMessage<RegisterProductCommand>
    {
        public ProductSaga(IBus bus, IEventStore eventStore, IRepository repository)
            : base(bus, eventStore, repository)
        {

        }

        public void Handle(RegisterProductCommand message)
        {
            var product = new ProductAggregate();
            product.CreateProduct(message.ProductId, message.ProductName, message.Price);
            this.Repository.Save(product);
        }
    }
}
