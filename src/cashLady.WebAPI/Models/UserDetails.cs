using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashLady.WebAPI.Models
{
    public class UserDetails
    {
        public string Email { get; set; }

        public string Title { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int PhoneNumber { get; set; }

        public DateTime DoB { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }

        public string Pin { get; set; }

        public Guid LoanId { get; set; }

        public int LoanAmount { get; set; }

        public int Years { get; set; }

        public string APR { get; set; }

        public decimal MonthlyPayment { get; set; }

        public Guid UserId { get; set; }
    }
}