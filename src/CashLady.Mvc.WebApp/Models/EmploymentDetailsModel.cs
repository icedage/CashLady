namespace CashLady.Mvc.WebApp.Models
{
    public class EmploymentDetailsModel
    {
        public decimal NetSalary { get; set; }

        public string NationalInsuranceNumber { get; set; }
        
        public string CurrentEmployment { get; set; }
        
        public string CurrentPosition { get; set; }

        public int YearsWithCurrentEmployer { get; set; }
    }
}