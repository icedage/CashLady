using System;
using System.Threading.Tasks;
using CashLady.CqrsLib;
using MassTransit;
using CashLady.Domain.Version1.Commands;

namespace CashLady.Services.CommandHandlers.Loan
{
    public class ApplyForLoanHandler : IConsumer<ApplyForLoan>
    {
        public Task Consume(ConsumeContext<ApplyForLoan> context)
        {
            //Console.Write("  TXT: " + context.Message.What);
            //Console.Write("  SENT: " + context.Message.When);
            //Console.Write("  PROCESSED: " + DateTime.Now);
            //Console.WriteLine(" (" + System.Threading.Thread.CurrentThread.ManagedThreadId + ")");
            return Task.FromResult(0);
        }
    }
}
