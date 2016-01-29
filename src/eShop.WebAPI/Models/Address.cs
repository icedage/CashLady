using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShop.WebAPI.Models
{
    public class Address
    {
        public string FirstLine { get; set; }

        public string PostCode { get; set; }

        public DateTime DateMovedIn { get; set; }
    }
}