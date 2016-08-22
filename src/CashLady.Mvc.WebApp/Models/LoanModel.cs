using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashLady.Mvc.WebApp.Models
{
    public class LoanApplyModel
    {
        public int LoanAmount { get; set; }

        public int Years { get; set; }

        public string APR { get; set; }

        public decimal MonthlyPayment { get; set; }
    }
}