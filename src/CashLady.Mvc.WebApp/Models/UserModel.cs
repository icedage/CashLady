using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CashLady.Mvc.WebApp.Models
{
    public class UserModel
    {
        public string Email { get; set; }

        public string Title { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DoB { get; set; }

        public int LoanAmount { get; set; }

        public int Years { get; set; }

        public string APR { get; set; }

        public decimal MonthlyPayment { get; set; }

        public IEnumerable<TitleModel> Titles { get; set; }

        public int TitleId { get; set; }
    }
}