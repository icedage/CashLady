using CashLady.CqrsLib;
using CashLady.Domain.Version1.Events;
using System;

namespace CashLady.Services.Domain.User
{
    public class UserAggregate : AggregateRoot
    {
        private Guid userId;
        private string _email { get; set; }
        private string _title { get; set; }
        private string _firstname { get; set; }
        private string _lastname { get; set; }
        private int _phoneNumber { get; set; }
        private DateTime _doB { get; set; }
        private string _loanReason { get; set; }
        private decimal _annualIncomeBeforeTax { get; set; }
        private string _homeOwnership { get; set; }
        private decimal _monthlyRentContribution { get; set; }
        private decimal _monthlyMortgageContribution { get; set; }
        private string _employmentStatus { get; set; }

        public UserAggregate()
        {
            
        }

        public override Guid Id
        {
            get
            {
                return this.userId;
            }
        }

        public void RegisterUser(UserDetails userDetails)
        {
            this.ApplyChange(new UserRegistered() {
                                                        AnnualIncomeBeforeTax= userDetails.AnnualIncomeBeforeTax,
                                                        DoB = userDetails.DoB,
                                                        Email = userDetails.Email,
                                                        EmploymentStatus = userDetails.EmploymentStatus,
                                                        HomeOwnership = userDetails.HomeOwnership,
                                                        Firstname = userDetails.Firstname,
                                                        Lastname = userDetails.Lastname,
                                                        LoanReason= userDetails.LoanReason,
                                                        MonthlyMortgageContribution= userDetails.MonthlyMortgageContribution,
                                                        MonthlyRentContribution = userDetails.MonthlyRentContribution,
                                                        PhoneNumber = userDetails.PhoneNumber,
                                                        Title= userDetails.Title,
                                                        UserId = userDetails.UserId
                                                  });
        }

        public void Apply(UserRegistered @event)
        {
            _email = @event.Email;
            _title = @event.Title;
            _firstname = @event.Firstname;
            _lastname = @event.Lastname;
            _phoneNumber = @event.PhoneNumber;
            _doB = @event.DoB;
            _loanReason = @event.LoanReason;
            _annualIncomeBeforeTax = @event.AnnualIncomeBeforeTax;
            _homeOwnership = @event.HomeOwnership;
            _monthlyMortgageContribution = @event.MonthlyMortgageContribution;
            _monthlyRentContribution = @event.MonthlyRentContribution;
            _employmentStatus = @event.EmploymentStatus;
        }
    }
}
