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
    public class UserController : ApiController
    {
        private readonly ICommandSender _command;

        public UserController(ICommandSender command)
        {
            _command = command;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(UserDetails userDetails)
        {
            var userId = Guid.NewGuid();

            //Create User
            _command.Send(new UserRegister()
            {
                Firstname = userDetails.Firstname,
                Lastname= userDetails.Lastname,
                DoB = userDetails.DoB,
                Title = userDetails.Title
            });

            //Add loan
            _command.Send(new ApplyForLoan()
            {
                
            });

            return Ok();
        }
    }
}
