using System.Web.Http;
using CashLady.CqrsLib;
using CashLady.Domain.Version1.Commands;
using CashLady.WebAPI.Models;
using System;
using CashLady.Services.Generators;
using CashLady.Denormalizer.MongoDB.MongoRepository;

namespace CashLady.WebAPI.Controllers
{
    public class LoansController : ApiController
    {
        private readonly ICommandSender _command;
        private readonly ILoansViewRepository _loansViewRepository;
        // private readonly IUniqueRefService _uniqueRefService;

        public LoansController(ICommandSender command)
        {
            _command = command;
            //_loansViewRepository = loansViewRepository;
            //_uniqueRefService = uniqueRefService;
        }

        [HttpGet]
        [Authorize(Roles ="SuperUser")]
        public IHttpActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Post(LoanRequest loanRequest)
        {
            var userId = Guid.NewGuid();
           // string friendlyRef = _uniqueRefService.GetNewReference();

            _command.Send(new ApplyForLoan()
            {
                Apr = loanRequest.LoanDetails.Apr,
                MonthlyPayment = loanRequest.LoanDetails.MonthlyCost,
                LoanAmount = loanRequest.LoanDetails.LoanAmount,
                Term = loanRequest.LoanDetails.Term,
                
                UserId = userId
            });

            _command.Send(new UserRegister()
            {
                Title = loanRequest.UserDetails.Title,
                Firstname = loanRequest.UserDetails.Firstname,
                Lastname = loanRequest.UserDetails.Lastname,
                Email = loanRequest.UserDetails.Email,
                PhoneNumber = loanRequest.UserDetails.PhoneNumber,
                DoB = loanRequest.UserDetails.DoB,
                AnnualIncomeBeforeTax = loanRequest.FinancialDetails.AnnualIncomeBeforeTax,
                MonthlyMortgageContribution = loanRequest.FinancialDetails.MonthlyMortgageContribution,
                MonthlyRentContribution = loanRequest.FinancialDetails.MonthlyRentContribution,
                LoanReason = loanRequest.LoanReason.Reason,
                EmploymentStatus = loanRequest.FinancialDetails.Employment.EmploymentStatus,
                UserId= userId
            });

            return Ok(new { LoanRed = "Test" });
        }
    }
}