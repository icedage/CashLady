using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.Contracts.WebApp
{
    public class LoanApplication
    {
        public string Email { get; set; }

        public string Title { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DoB { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string Address4 { get; set; }

        public string Address5 { get; set; }

        public int LoanAmount { get; set; }

        public int Years { get; set; }

        public string APR { get; set; }

        public decimal MonthlyPayment { get; set; }

        public decimal NetSalary { get; set; }

        public string NationalInsuranceNumber { get; set; }

        public string CurrentEmployment { get; set; }

        public string CurrentPosition { get; set; }

        public int YearsWithCurrentEmployer { get; set; }
    }
}
