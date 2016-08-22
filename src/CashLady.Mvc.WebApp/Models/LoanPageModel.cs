using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CashLady.Mvc.WebApp.Views.User
{
    public class LoanPageModel
    {
        public IEnumerable<SelectListItem> LoanAmounts { get; set; }

        public string APR { get; set; }

        public IEnumerable<SelectListItem> MonthlyPayments { get; set; }
    }
}