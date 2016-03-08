using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashLady.WebAPI.Models
{
    public class LoanDetails
    {
        public decimal Apr { get; set; }    

        public int Term { get; set; }

        public decimal MonthlyCost { get; set; }

        public decimal LoanAmount { get; set; }
    }
}