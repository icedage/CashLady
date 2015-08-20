using eShop.Infrastructure;
using eShop.UserRegistry.CommandStack.Commands;
using eShop.UserRegistry.CommandStack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UserRegistry.CommandStack.Sagas
{
    public class ProductSaga : Saga,
        IHandleMessage<RegisterProductCommand>
    {
        public void Handle(RegisterProductCommand message)
        {
            var product = new ProductAggregate();
            product.CreateProduct(message.ProductId, message.Name, message.Price);
            this.Repository.Save(product);
        }
    }
}
