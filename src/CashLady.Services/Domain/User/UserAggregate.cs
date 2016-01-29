using CashLady.CqrsLib;
using System;

namespace CashLady.Services.Domain.User
{
    public class UserAggregate : AggregateRoot
    {
        public override Guid Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
