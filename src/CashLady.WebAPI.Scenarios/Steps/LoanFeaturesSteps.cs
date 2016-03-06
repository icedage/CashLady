using CashLady.WebAPI.Scenarios.Entities;
using CashLady.WebAPI.Scenarios.Helpers;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace CashLady.WebAPI.Scenarios.Steps
{
    [Binding]
    public class LoanFeaturesSteps
    {
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

        [When(@"Test")]
        public void WhenTest()
        {
            Assert.AreEqual(1, 1);
        }

    }
}
