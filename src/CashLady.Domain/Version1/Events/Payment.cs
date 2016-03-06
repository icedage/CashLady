using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.Domain.Version1.Events
{
    public class Payment
    {
        public DateTime PaymentDate { get; set; }

        public DateTime PaidDate { get; set; }

        public decimal StartingBalance { get; set; }

        public decimal PaymentAmount { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal Interest { get; set; }

        public decimal Principle { get; set; }

        public decimal ArrearBalance { get; set; }

        public decimal EndBalance { get; set; }

        public decimal OutstandingBalance { get; set; }

        public decimal IRR { get; set; }
    }
}
