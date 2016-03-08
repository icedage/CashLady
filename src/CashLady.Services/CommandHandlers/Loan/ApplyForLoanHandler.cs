using System;
using System.Threading.Tasks;
using CashLady.CqrsLib;
using MassTransit;
using CashLady.Domain.Version1.Commands;
using CashLady.Services.Domain.Loan;

namespace CashLady.Services.CommandHandlers.Loan
{
    public class ApplyForLoanHandler : IConsumer<ApplyForLoan>
    {
        private readonly IRepository<LoanAggregate> _repository;

        public ApplyForLoanHandler(IRepository<LoanAggregate> repository)
        {
            _repository = repository;
        }

        public Task Consume(ConsumeContext<ApplyForLoan> context)
        {
            var loanAggregate = new LoanAggregate();
            loanAggregate.ApplyForLoan(new Domain.Loan.Loan()
            {
                Apr = context.Message.Apr,
                MonthlyPayment = context.Message.MonthlyPayment,
                Term = context.Message.Term,
                TotalRepayment = context.Message.TotalRepayment,
                OriginationFee = context.Message.OriginationFee,
                TotalInterest = context.Message.TotalInterest
            });
            _repository.Save(loanAggregate);
            return Task.FromResult(0);
        }
    }
}
