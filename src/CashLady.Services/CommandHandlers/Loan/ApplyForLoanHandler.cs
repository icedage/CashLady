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
            //Console.Write("  TXT: " + context.Message.What);
            //Console.Write("  SENT: " + context.Message.When);
            //Console.Write("  PROCESSED: " + DateTime.Now);
            //Console.WriteLine(" (" + System.Threading.Thread.CurrentThread.ManagedThreadId + ")");
            var loanAggregate = new LoanAggregate();
            _repository.Save(loanAggregate);
            return Task.FromResult(0);
        }
    }
}
