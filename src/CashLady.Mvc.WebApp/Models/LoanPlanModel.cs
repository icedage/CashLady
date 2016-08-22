using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashLady.Mvc.WebApp.Models
{
    public class LoanPlanModel
    {
        public int PaymentId { get; set; }

        public int MonthlyPaymentId { get; set; }

        public IList<PaymentsPlan> PaymentsPlans { get; set; }

        public IList<MonthlyPayment> MonthlyPayments { get; set; }
    }
}