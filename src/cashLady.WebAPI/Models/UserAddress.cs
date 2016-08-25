using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashLady.WebAPI.Models
{
    public class UserAddress
    {
        public Guid UserId { get; set; }

        public IList<Address> Addresses { get; set; }
    }
}