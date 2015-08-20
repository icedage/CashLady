using eShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UserRegistry.CommandStack.Events
{
    public class ProductAdded : DomainEvent
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }
    }
}
