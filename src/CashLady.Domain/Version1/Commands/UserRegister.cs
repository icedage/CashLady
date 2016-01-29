using CashLady.CqrsLib;

namespace CashLady.Domain.Version1.Commands
{
    public class UserRegister : Command
    {
        public string Email { get; set; }

        public string Title { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int PhoneNumber { get; set; }

        public decimal AnnualIncomeBeforeTax { get; set; }

        public string HomeOwnership { get; set; }

        public decimal MonthlyRentContribution { get; set; }

        public decimal MonthlyMortgageContribution { get; set; }
    }
}
