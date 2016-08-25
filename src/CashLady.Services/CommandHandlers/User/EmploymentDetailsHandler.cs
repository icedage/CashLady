using System;
using System.Threading.Tasks;
using CashLady.CqrsLib;
using CashLady.Domain.Version1.Commands;
using CashLady.Services.Domain.User;
using MassTransit;

namespace CashLady.Services.CommandHandlers.User
{
    public class EmploymentDetailsHandler : IConsumer<RegisterEmploymentDetails>
    {
        private readonly IRepository<UserAggregate> repository;

        public EmploymentDetailsHandler(IRepository<UserAggregate> repository)
        {
            this.repository = repository;
        }

        public Task Consume(ConsumeContext<RegisterEmploymentDetails> context)
        {
            var userAggregate = this.repository.GetById(context.Message.UserId);

            throw new NotImplementedException();
        }
    }
}
