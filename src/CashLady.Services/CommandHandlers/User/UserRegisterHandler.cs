using CashLady.CqrsLib;
using CashLady.Domain.Version1.Commands;
using CashLady.Services.Domain.User;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace CashLady.Services.CommandHandlers.User
{
    public class UserRegisterHandler : IConsumer<UserRegister>
    {
        private readonly IRepository<UserAggregate> repository;

        public UserRegisterHandler(IRepository<UserAggregate> repository)
        {
            this.repository = repository;
        }

        public async Task Consume(ConsumeContext<UserRegister> context)
        {
            var aggregate = new UserAggregate();
            aggregate.RegisterUser(new UserDetails());

            repository.Save(aggregate);
        }
    }
}
