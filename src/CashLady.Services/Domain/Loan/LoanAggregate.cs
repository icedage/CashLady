using System;
using CashLady.CqrsLib;
using CashLady.Domain.Version1.Events;

namespace CashLady.Services.Domain.Loan
{
    public class LoanAggregate : AggregateRoot
    {
        private Guid loanId;
        private decimal _apr { get; set; }
        private int _term { get; set; }
        private decimal _monthlyPayment { get; set; }
        private decimal _originationFee { get; set; }
        private decimal _totalRepayment { get; set; }
        private decimal  _totalInterest { get; set; }

        public LoanAggregate()
        {
            this.loanId = Guid.NewGuid();
        }

        public override Guid Id
        {
            get { return this.loanId; }
        }

        public void ApplyForLoan(Loan loan)
        {
            this.ApplyChange(new LoanApplicationCompleted()
            {
                Apr = loan.Apr,
                MonthlyPayment = loan.MonthlyPayment,
                OriginationFee = loan.OriginationFee,
                Term = loan.Term,
                TotalRepayment = loan.TotalRepayment,
                TotalInterest = loan.TotalInterest
            });
        }

        public void Apply(LoanApplicationCompleted @event)
        {
            _apr = @event.Apr;
            _monthlyPayment = @event.MonthlyPayment;
            _originationFee = @event.OriginationFee;
            _term = @event.Term;
            _totalInterest = @event.TotalInterest;
            _totalRepayment = @event.TotalRepayment;
        }
    }
}
