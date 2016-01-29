using System;
using CashLady.CqrsLib;

namespace CashLady.Services.Domain.Loan
{
    public class LoanAggregate : AggregateRoot
    {
        private Guid loanId;

        public LoanAggregate()
        {
            this.loanId = Guid.NewGuid();
        }

        public override Guid Id
        {
            get { return this.loanId; }
        }
    }
}
