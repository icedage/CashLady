using CashLady.CqrsLib;
using System;

namespace CashLady.Domain.Version1.Commands
{
    public class ApplyForLoan : Command
    {
        public Guid LoanId { get; set; }

        public int LoanAmount { get; set; }

        public int Years { get; set; }

        public string APR { get; set; }

        public decimal MonthlyPayment { get; set; }

        public Guid UserId { get; set; }
    }
}
