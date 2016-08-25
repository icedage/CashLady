using System;
using System.Threading.Tasks;
using CashLady.Contracts.WebApp;
using System.Net.Http;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http.Headers;
using System.Text;

namespace CashLady.Gateway.RestHelpers
{
    public class RestHelper : IRestHelper
    {
        public RestResponse DoGetRequest()
        {
            throw new NotImplementedException();
        }

        public async Task<RestResponse> DoPostRequest(string data, string suffix)
        {
            var client = new HttpClient();

            var address = string.Format("{0}{1}", ConfigurationManager.AppSettings["CashLady.WebApi"],suffix);

         
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "relativeAddress");
            var content = new StringContent(data,
                                                Encoding.UTF8,
                                                "application/json");

            var response = await client.PostAsync(address,content);

            return new RestResponse()
            {
                Content = await response.Content.ReadAsStringAsync(),
                HttpStatusCode = response.StatusCode
            };
        }
    }
}
