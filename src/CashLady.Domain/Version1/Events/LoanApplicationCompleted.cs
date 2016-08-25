using CashLady.CqrsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.Domain.Version1.Events
{
    public class LoanApplicationCompleted : Event
    {
        public Guid UserId { get; set; }
        public decimal Apr { get; set; }

        public int Term { get; set; }

        public decimal MonthlyPayment { get; set; }

        public decimal OriginationFee { get; set; }
        
        public decimal TotalRepayment { get; set; }

        public decimal TotalInterest { get; set; }
    }
}
