using System;
using System.Threading.Tasks;
using CashLady.Contracts.WebApp;
using System.Net.Http;
using Newtonsoft.Json;
using System.Configuration;

namespace CashLady.Gateway.RestHelpers
{
    public class RestHelper : IRestHelper
    {
        public RestResponse DoGetRequest()
        {
            throw new NotImplementedException();
        }

        public async Task<RestResponse> DoPostRequest(StringContent data, string suffix)
        {
            var client = new HttpClient();

            //  var stringContent = new StringContent(JsonConvert.SerializeObject(user));

            var response = await client.PostAsync(ConfigurationManager.AppSettings["CachLady.WebApi"], data);

            return new RestResponse()
            {
                Content = await response.Content.ReadAsStringAsync(),
                HttpStatusCode = response.StatusCode
            };
        }
    }
}
