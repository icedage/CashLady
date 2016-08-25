using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashLady.WebAPI.Models
{
    public class EmploymentDetails
    {
        public Guid UserId { get; set; }

        public decimal NetSalary { get; set; }

        public string NationalInsuranceNumber { get; set; }

        public string CurrentEmployment { get; set; }

        public string CurrentPosition { get; set; }

        public int YearsWithCurrentEmployer { get; set; }
    }
}