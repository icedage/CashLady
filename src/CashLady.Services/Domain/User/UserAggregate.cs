using CashLady.CqrsLib;
using CashLady.Domain.Version1.Events;
using System;

namespace CashLady.Services.Domain.User
{
    public class UserAggregate : AggregateRoot
    {
        private Guid userId;

        public UserAggregate()
        {
            
        }

        public override Guid Id
        {
            get
            {
                return this.userId;
            }
        }

        public void RegisterUser(UserDetails userDetails)
        {
            this.ApplyChange(new UserRegistered() { });
        }

        public void Apply(UserRegistered @event)
        {
            
        }
    }
}
