using CashLady.Mvc.WebApp.Models;
using CashLady.Mvc.WebApp.Presenters;
using System.Web.Mvc;

namespace CashLady.Mvc.WebApp.Controllers
{
    public class LoanController : Controller
    {
        private readonly ILoanPresenter _loanPresenter;

        public LoanController()
        {
            _loanPresenter = new LoanPresenter();
        }
        // GET: Loan
        public ActionResult LoanPage()
        {
            var loanPlan = new LoanPlanModel()
            {
                MonthlyPayments = _loanPresenter.MonthlyPayments(),
                PaymentsPlans = _loanPresenter.GetPayments()
            };
            return View(loanPlan);
        }
    }
}