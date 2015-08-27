using eShop.Infrastructure;
using System;

namespace eShop.UserRegistry.CommandStack.Commands
{
    public class RegisterProductCommand : Command
    {
        public Guid ProductId { get; set; }
         
        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Location { get; set; }
    }
}
