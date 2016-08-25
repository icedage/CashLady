using System;
using System.Collections.Generic;
using CashLady.CqrsLib;
using CashLady.Domain.Entities;

namespace CashLady.Domain.Version1.Commands
{
    public class UserAddressDetails : Command
    {
        public Guid UserId { get; set; }

        public IList<Address> Addresses { get; set; }
    }
}
