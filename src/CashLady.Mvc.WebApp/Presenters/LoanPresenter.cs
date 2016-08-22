using System.Collections.Generic;
using CashLady.Mvc.WebApp.Models;
using CashLady.Contracts.WebApp;

namespace CashLady.Mvc.WebApp.Presenters
{
    public class LoanPresenter : ILoanPresenter
    {

        public void Apply(LoanApplication application)
        {

        }

        public IList<MonthlyPayment> MonthlyPayments()
        {
            var payments = new List<MonthlyPayment>()
            {
                new MonthlyPayment() { Text = "£2,148.75", Value = 2148.75M },
                new MonthlyPayment() { Text = "£1,105.16", Value = 1105.16M },
                new MonthlyPayment() { Text = "£757.68"  , Value = 757.68M  },
                new MonthlyPayment() { Text = "£584.22"  , Value = 584.22M  },
                new MonthlyPayment() { Text = "£480.38"  , Value = 480.38M  }
            };

            return payments;
        }

        public IList<PaymentsPlan> GetPayments()
        {
            var years = new List<PaymentsPlan>()
            {
                new PaymentsPlan() {Text = "1 year",  Months=12 },
                new PaymentsPlan() {Text = "2 years", Months=24 },
                new PaymentsPlan() {Text = "3 years", Months=36 },
                new PaymentsPlan() {Text = "4 years", Months=48 },
                new PaymentsPlan() {Text = "5 years", Months=56 }
            };

            return years;
        }
    }
}