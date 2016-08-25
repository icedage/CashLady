using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashLady.CqrsLib;
using CashLady.Domain.Entities;

namespace CashLady.Domain.Version1.Events
{
    public class UserAddress : Event
    {
        public Guid UserId { get; set; }
        public IList<Address> Addresses { get; set; }
    }
}
