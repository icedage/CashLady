using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.WebAPI.Scenarios.Entities
{
    public class LoanDetails
    {
        public string Apr { get; set; }

        public int Term { get; set; }

        public decimal MonthlyCost { get; set; }

        public decimal LoanAmount { get; set; }
    }
}
