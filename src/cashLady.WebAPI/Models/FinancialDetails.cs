using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShop.WebAPI.Models
{
    public class FinancialDetails
    {
        public Employment Employment { get; set; }

        public decimal AnnualIncomeBeforeTax { get; set; }

        public string HomeOwnership { get; set; }

        public decimal MonthlyRentContribution { get; set; }

        public decimal MonthlyMortgageContribution { get; set; }
    }
}