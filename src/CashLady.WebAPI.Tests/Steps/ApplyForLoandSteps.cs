using System;
using System.Collections.Generic;
using CashLady.WebAPI.Tests.Helpers;
using RestSharp;
using TechTalk.SpecFlow;

namespace CashLady.WebAPI.Tests.Steps
{
    [Binding]
    public class ApplyForLoandSteps
    {
        private RestSharpWrapper _restSharpWrapper;

        [Given(@"user applies for a loan")]
        public void GivenUserAppliesForALoan()
        {
            var request = new RestSharpWrapper("http://localhost:50022", "/api/behaviours/?behaviourId=CmsListProperties&message=AddProperty", Method.POST);

            var headers = new Dictionary<string, string>
            {
                { "Referer", "http://localhost:50022/edit/"},
            };

             var encodedBody = string.Format("name={0}&lat={1}&lng={2}&searchPrice={3}&typeid={4}&bedrooms={5}&requiredIncome={6}&stationName={7}" +
                                           "&typeStation={8}&distanceToStation={9}&localAreaInformation={10}&propertyDescription={11}&propertyDetails={12}&yourMonthlyRentForm={13}",);

            ScenarioContext.Current.Pending();
        }
        
        [Given(@"details are correct")]
        public void GivenDetailsAreCorrect()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the system should create an account for the user")]
        public void ThenTheSystemShouldCreateAnAccountForTheUser()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"it should save user details")]
        public void ThenItShouldSaveUserDetails()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"it should return a loan reference number")]
        public void ThenItShouldReturnALoanReferenceNumber()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
