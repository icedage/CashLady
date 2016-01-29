using CashLady.CqrsLib;

namespace CashLady.Domain.Version1.Commands
{
    public class ApplyForLoan : Command
    {
        public decimal Apr { get; set; }

        public int Term { get; set; }

        public decimal MonthlyPayment { get; set; }

        public decimal OriginationFee { get; set; }

        public decimal TotalRepayment { get; set; }

        public decimal TotalInterest { get; set; }
    }
}
