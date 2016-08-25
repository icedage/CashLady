using CashLady.Contracts.WebApp;
using CashLady.Gateway.RestHelpers;
using CashLady.Mvc.WebApp.Models;
using CashLady.Mvc.WebApp.Presenters;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CashLady.Mvc.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IRestHelper _restHelper;
        private readonly IUserPresenter presenter;
        private readonly ILoanPresenter loanPresenter;


        public UserController()
        {
            this.presenter = new UserPresenter();
            this.loanPresenter = new LoanPresenter();
            this._restHelper = new RestHelper();
        }

        // GET: User
        [HttpGet]
        public ActionResult UserDetails()
        {
            var userModel = new UserModel()
            {
                Titles = presenter.Titles()
            };

            return View(userModel);
        }

        [HttpPost]
        public async Task<ActionResult> UserDetails(UserModel model)
        {
            var user = new User()
            {
                DoB = model.DoB,
                Email = model.Email,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                PhoneNumber = model.PhoneNumber,
                Title = model.Title,
                
            };

          
            var response = await _restHelper.DoPostRequest(JsonConvert.SerializeObject(user), "api/user");
    
            return Json(response);
        }

        public ActionResult LoanPage()
        {
            var loanPlan = new LoanPlanModel()
            {
                MonthlyPayments = loanPresenter.MonthlyPayments(),
                PaymentsPlans = loanPresenter.GetPayments()
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