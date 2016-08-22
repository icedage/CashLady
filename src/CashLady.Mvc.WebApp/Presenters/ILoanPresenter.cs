using CashLady.Mvc.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.Mvc.WebApp.Presenters
{
    public interface ILoanPresenter
    {
        IList<MonthlyPayment> MonthlyPayments();

        IList<PaymentsPlan> GetPayments();
    }
}
