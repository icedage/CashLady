using System.Web.Http;
using CashLady.CqrsLib;
using CashLady.Domain.Version1.Commands;
using CashLady.WebAPI.Models;
using System;
using CashLady.Services.Generators;
using CashLady.Denormalizer.MongoDB.MongoRepository;
using System.Configuration;
using CashLady.Denormalizer.MongoDB.Repositories;
using System.Linq;

namespace CashLady.WebAPI.Controllers
{
    public class LoansController : ApiController
    {
        private readonly ICommandSender _command;
        private ILoansViewRepository _loansViewRepository;
        
        public LoansController(ICommandSender command)
        {
            _command = command;
            //TODO : Need to fix the denendency issue with the ILoansViewRepository!!
            var connection = ConfigurationManager.AppSettings["MongoDBconnection"];
            MongoContextProvider contextProvider = new MongoContextProvider(connection, "LoansViewRepository");
            _loansViewRepository = new LoansViewRepository(contextProvider);
        }

        [HttpGet]
        [Authorize(Roles ="SuperUser")]
        public IHttpActionResult Get()
        {
            var loans = _loansViewRepository.All();
            return Ok(loans.ToList());
        }

        [HttpPost]
        public IHttpActionResult Post(LoanRequest loanRequest)
        {
            var userId = Guid.NewGuid();
           
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

            //Implement Service to generate a ref number
            var quote = "Test"; 
            return Ok(new { LoanRed = quote });
        }
    }
}