using CashLady.CqrsLib;
using CashLady.Domain.Version1.Commands;
using CashLady.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CashLady.WebAPI.Controllers
{
    [Route("api/user")]
    public class UserController : ApiController
    {
        private readonly ICommandSender _command;

        public UserController(ICommandSender command)
        {
            _command = command;
        }

        [HttpPost]
        public IHttpActionResult Post(UserDetails userDetails)
        {
            var userId = Guid.NewGuid();
            var loanId = Guid.NewGuid();

            //Create User
            _command.Send(new UserRegister()
            {
                UserId = userId,
                Firstname = userDetails.Firstname,
                Lastname= userDetails.Lastname,
                DoB = userDetails.DoB,
                Title = userDetails.Title,
                Email = userDetails.Email,
                PhoneNumber = userDetails.PhoneNumber
            });

            //Add loan
            _command.Send(new ApplyForLoan()
            {
                UserId = userId,
                LoanId = loanId,
                APR = userDetails.APR,
                LoanAmount = userDetails.LoanAmount,
                MonthlyPayment = userDetails.MonthlyPayment,
                Years = userDetails.Years
            });

            return Ok();
        }

        [HttpPost]
        [Route("userAddresses")]
        [Authorize]
        public IHttpActionResult Post(UserAddress userAddress)
        {
           _command.Send(new UserAddressDetails()
            {
                Addresses = userAddress.Addresses.Select(x => new CashLady.Domain.Entities.Address()
                {
                    City = x.City,
                    County = x.County,
                    DateMovedIn = x.DateMovedIn,
                    DateMovedOut = x.DateMovedOut,
                    FirstLine = x.FirstLine,
                    PostCode = x.PostCode
                }).ToList(),
                UserId = userAddress.UserId
            });

            return Ok();
        }

        [HttpPost]
        [Route("employmentDetails")]
        [Authorize]
        public IHttpActionResult Post(EmploymentDetails employmentDetails)
        {
            _command.Send(new RegisterEmploymentDetails()
            {
               UserId = employmentDetails.UserId,
               CurrentEmployment = employmentDetails.CurrentEmployment,
               CurrentPosition = employmentDetails.CurrentPosition,
               NationalInsuranceNumber = employmentDetails.NationalInsuranceNumber,
               NetSalary = employmentDetails.NetSalary,
               YearsWithCurrentEmployer = employmentDetails.YearsWithCurrentEmployer
            });

            return Ok();
        }
    }
}
