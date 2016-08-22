using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashLady.Mvc.WebApp.Models
{
    public class UserRegistrationModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}