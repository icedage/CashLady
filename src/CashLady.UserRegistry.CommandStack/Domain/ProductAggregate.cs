using eShop.Infrastructure;
using eShop.UserRegistry.CommandStack.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UserRegistry.CommandStack.Domain
{
    public class ProductAggregate : Aggregate
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public void CreateProduct(Guid productId, string name, decimal price )
        {
            var @event= new ProductAdded(){ProductId=productId,ProductName=name,Price=price};
            this.RaiseEvent(@event);
        }

        public void Apply(ProductAdded @event)
        {
            this.Id = @event.ProductId;
            this.Name = @event.ProductName;
            this.Price = @event.Price;
        }
    }
}
