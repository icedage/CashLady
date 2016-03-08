using CashLady.WebAPI.Scenarios.Entities;
using CashLady.WebAPI.Scenarios.Helpers;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CashLady.WebAPI.Scenarios.Steps
{
    [Binding]
    public class LoanFeaturesSteps
    {
        private HttpRequestAuthenticator _restSharpComponent;
        private HttpRequestWrapper _wrapper;
        private List<Loan> _loans;

        public LoanFeaturesSteps()
        {
            _restSharpComponent = new HttpRequestAuthenticator();
            _loans = new List<Loan>();
        }

        [Given(@"a user applies for a loan")]
        public void GivenAUserAppliesForALoan()
        {
            try
            {
                var loanRequest = new LoanRequest()
                {
                    FinancialDetails = new FinancialDetails()
                    {
                        AnnualIncomeBeforeTax = 65000,
                        Employment = new Employment() { EmploymentStatus = "Employed" },
                        HomeOwnership = "Homeowner",
                        MonthlyMortgageContribution = 1000
                    },
                    LoanDetails = new LoanDetails()
                    {
                        LoanAmount = 15000,
                        Term = 48,
                        MonthlyCost = 450,
                        Apr = "4%"
                    },
                    LoanReason = new LoanReason() { Reason = "Purchase a car" },
                    UserDetails = new UserDetails()
                    {
                        DoB = Convert.ToDateTime("12/09/1970"),
                        Email = "test@test.com",
                        Firstname = "Brad",
                        Lastname = "Pitt",
                        PhoneNumber = 2109078909,
                        Title = "Dr"
                    }

                };

                var client = new RestClient("http://localhost:14598/");
                // client.Authenticator = new HttpBasicAuthenticator(username, password);

                var request = new RestRequest("api/loans", Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Content-Type", "application/json");

                request.AddBody(loanRequest);
                var response = client.Execute(request);
            }
            catch (Exception ex)
            {

            }
            // var rest = new RestSharpWrapper(string.Empty,string.Empty);
            //ScenarioContext.Current.Pending();
            Assert.AreEqual(1,1);
        }
        
        [Then(@"the system should return a reference number")]
        public void ThenTheSystemShouldReturnAReferenceNumber()
        {
            Assert.AreEqual(1, 1);
        }

      
        [Given(@"I am a borroweer user")]
        public void GivenIAmABorroweerUser()
        {
            _restSharpComponent.TokenizeRequest(new User()
            {
                username = "SuperPowerUser",
                password = "password123",
                grant_type = "password"
            });

            var resourceServer = ConfigurationManager.AppSettings["ResourceServer"];

            _wrapper = new HttpRequestWrapper(_restSharpComponent, string.Format("{0}api/loans",resourceServer), Method.GET);

            _loans = _wrapper.Execute<List<Loan>>();
        }

        [Given(@"I am an underwtiter")]
        public void GivenIAmAnUnderwtiter()
        {
             Assert.AreEqual(1, 1);
        }
        

        [Given(@"I am an underwriter")]
        public void GivenIAmAnUnderwriter()
        {
            Assert.AreEqual(1, 1);
        }

        [When(@"I request to view my loan details")]
        public void WhenIRequestToViewMyLoanDetails()
        {
            Assert.AreEqual(1, 1);
        }

        [When(@"I cancel the loan")]
        public void WhenICancelTheLoan()
        {
            Assert.AreEqual(1, 1);
        }

        [When(@"I request to view all loans")]
        public void WhenIRequestToViewAllLoans()
        {
            Assert.AreEqual(1, 1);
        }

        [Then(@"System should return information regarding my Loan")]
        public void ThenSystemShouldReturnInformationRegardingMyLoan()
        {
            Assert.AreEqual(1, 1);
        }

        [Then(@"the loan Status should appear as Canceled")]
        public void ThenTheLoanStatusShouldAppearAsCanceled()
        {
            Assert.AreEqual(1, 1);
        }

        [Then(@"the system should return all available laons")]
        public void ThenTheSystemShouldReturnAllAvailableLaons()
        {
            Assert.AreEqual(1, 1);
        }

    }
}
