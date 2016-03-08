using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.WebAPI.Scenarios.Helpers
{
    public class LoanRequest
    {
        public UserDetails UserDetails { get; set; }

        public FinancialDetails FinancialDetails { get; set; }

        public LoanDetails LoanDetails { get; set; }

        public LoanReason LoanReason { get; set; }
    }
}
