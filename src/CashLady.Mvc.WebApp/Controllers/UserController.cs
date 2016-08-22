using CashLady.Contracts.WebApp;
using CashLady.Gateway.RestHelpers;
using CashLady.Mvc.WebApp.Models;
using CashLady.Mvc.WebApp.Presenters;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web.Mvc;

namespace CashLady.Mvc.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IRestHelper _restHelper;
        private readonly ILoanPresenter _loanPresenter;


        public UserController()
        {
            //_restHelper = restHelper;
        }

        // GET: User
        [HttpGet]
        public ActionResult UserDetails()
        {
            var userModel = new UserModel();

            return View(userModel);
        }

        [HttpPost]
        public ActionResult UserDetails(UserModel model)
        {
            var user = new User()
            {
                DoB = model.DoB,
                Email = model.Email,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                PhoneNumber = model.PhoneNumber,
                Title = model.Title
            };

            var content = new StringContent(JsonConvert.SerializeObject(user));

            var response = _restHelper.DoPostRequest(content,"api/user");
    
            return Json(response);
        }

        public ActionResult LoanPage()
        {
            var loanPlan = new LoanPlanModel()
            {
                MonthlyPayments = _loanPresenter.MonthlyPayments(),
                PaymentsPlans = _loanPresenter.GetPayments()
            };
            return View(loanPlan);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}