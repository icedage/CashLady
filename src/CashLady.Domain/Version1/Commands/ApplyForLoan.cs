using CashLady.CqrsLib;
using System;

namespace CashLady.Domain.Version1.Commands
{
    public class ApplyForLoan : Command
    {
        public decimal Apr { get; set; }

        public int Term { get; set; }

        public decimal MonthlyPayment { get; set; }

        public decimal LoanAmount { get; set; }

        public string FriendlyLoanReference { get; set; }
        
        public Guid UserId { get; set; }
    }
}
