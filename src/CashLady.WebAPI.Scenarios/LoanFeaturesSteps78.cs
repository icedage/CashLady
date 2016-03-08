using System;
using TechTalk.SpecFlow;

namespace CashLady.WebAPI.Scenarios
{
    [Binding]
    public class LoanFeaturesSteps78
    {
        [Then(@"System should return a list of loans")]
        public void ThenSystemShouldReturnAListOfLoans()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
