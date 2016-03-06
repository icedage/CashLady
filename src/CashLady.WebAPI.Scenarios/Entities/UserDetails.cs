using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.WebAPI.Scenarios.Entities
{
    public class UserDetails
    {
        public string Email { get; set; }

        public string Title { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int PhoneNumber { get; set; }

        public DateTime DoB { get; set; }

        private LoanReason LoanReason { get; set; }
    }
}
