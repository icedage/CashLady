using CashLady.CqrsLib;
using CashLady.Domain.Version1.Events;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CashLady.Domain.Entities;

namespace CashLady.Services.Domain.User
{
    public class UserAggregate : AggregateRoot
    {
        private Guid _userId;
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

        private IList<Address> _addresses { get; set; }

        private decimal _netSalary { get; set; }

        private string _nationalInsuranceNumber { get; set; }

        private string _currentEmployment { get; set; }

        private string _currentPosition { get; set; }

        private int _yearsWithCurrentEmployer { get; set; }

        public override Guid Id
        {
            get
            {
                throw new NotImplementedException();
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

        public void RegisterAddress(UserAddress address)
        {
            this.ApplyChange(new UserAddress()
            {
                Addresses = address.Addresses,
                UserId = address.UserId
            });
        }

        public void RegisterEmploymentDetails(EmploymentDetailsRegistered employmentDetailsRegistered)
        {
            this.ApplyChange(new EmploymentDetailsRegistered()
            {
                UserId = employmentDetailsRegistered.UserId,
                NetSalary = employmentDetailsRegistered.NetSalary,
                YearsWithCurrentEmployer = employmentDetailsRegistered.YearsWithCurrentEmployer,
                NationalInsuranceNumber = employmentDetailsRegistered.NationalInsuranceNumber,
                CurrentEmployment = employmentDetailsRegistered.CurrentEmployment,
                CurrentPosition = employmentDetailsRegistered.CurrentPosition
            });
        }

        private void Apply(UserRegistered @event)
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

        private void Apply(UserAddress @event)
        {
            _addresses = @event.Addresses;
            _userId = @event.UserId;
        }

        private void Apply(EmploymentDetailsRegistered @event)
        {
            _userId = @event.UserId;
            _netSalary = @event.NetSalary;
            _yearsWithCurrentEmployer = @event.YearsWithCurrentEmployer;
            _nationalInsuranceNumber = @event.NationalInsuranceNumber;
            _currentEmployment = @event.CurrentEmployment;
            _currentPosition = @event.CurrentPosition;

        }
    }
}
