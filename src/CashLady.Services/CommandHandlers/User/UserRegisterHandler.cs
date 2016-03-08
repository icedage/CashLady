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

        public Task Consume(ConsumeContext<UserRegister> context)
        {
            var aggregate = new UserAggregate();

            aggregate.RegisterUser(new UserDetails() {
                                                        AnnualIncomeBeforeTax = context.Message.AnnualIncomeBeforeTax,
                                                        DoB = context.Message.DoB,
                                                        Email = context.Message.Email,
                                                        EmploymentStatus = context.Message.EmploymentStatus,
                                                        Firstname = context.Message.Firstname,
                                                        HomeOwnership = context.Message.HomeOwnership,
                                                        Lastname = context.Message.Lastname,
                                                        LoanReason = context.Message.LoanReason,
                                                        MonthlyMortgageContribution= context.Message.MonthlyMortgageContribution,
                                                        MonthlyRentContribution = context.Message.MonthlyRentContribution,
                                                        PhoneNumber = context.Message.PhoneNumber,
                                                        Title = context.Message.Title,
                                                        UserId = context.Message.UserId
            });

            repository.Save(aggregate);

            return Task.FromResult(0);
        }
    }
}
