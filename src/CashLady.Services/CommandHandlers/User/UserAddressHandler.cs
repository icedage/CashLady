using System.Threading.Tasks;
using CashLady.CqrsLib;
using CashLady.Domain.Version1.Commands;
using CashLady.Domain.Version1.Events;
using CashLady.Services.Domain.User;
using MassTransit;

namespace CashLady.Services.CommandHandlers.User
{
    public class UserAddressHandler : IConsumer<UserAddressDetails>
    {
        private readonly IRepository<UserAggregate> repository;

        public UserAddressHandler(IRepository<UserAggregate> repository)
        {
            this.repository = repository;
        }

        public Task Consume(ConsumeContext<UserAddressDetails> context)
        {
            var userAggregate = this.repository.GetById(context.Message.UserId);

            userAggregate.RegisterAddress(new UserAddress()
            {
                Addresses = context.Message.Addresses,
                UserId = context.Message.UserId
            });

            this.repository.Save(userAggregate);

            return Task.FromResult(0);
        }
    }
}
