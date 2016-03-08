using System;

namespace CashLady.WebAPI.Models
{
    public class ProductRequest
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PhotoLocation { get; set; }
    }
}