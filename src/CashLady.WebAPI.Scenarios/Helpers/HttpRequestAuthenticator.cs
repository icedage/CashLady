using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Configuration;
using System.Web.Script.Serialization;

namespace CashLady.WebAPI.Scenarios.Helpers
{
    public class HttpRequestAuthenticator : RestSharpComponent
    {
        private IRestRequest _restRequest;

        public HttpRequestAuthenticator()
        {
            var authorizationServer = ConfigurationManager.AppSettings["AuthorizationServer"];
            _restRequest = new RestRequest("oauth/token", Method.POST);
        }

        public void TokenizeRequest(User user)
        {
            var token = GetToken(user);
            Request.AddHeader("Accept", "application/json");
            Request.AddHeader("Content-Type", "application/json");
            Request.AddHeader("Authorization", string.Format("Bearer {0}", token));
        }

        private string GetToken(User user)
        {
            string encodedBody = string.Format("grant_type={0}&username={1}&password={2}", "password", "SuperPowerUser", "password123");
            _restRequest.AddParameter("application/x-www-form-urlencoded", encodedBody, ParameterType.RequestBody);
            _restRequest.AddParameter("Content-Type", "application/x-www-form-urlencoded", ParameterType.HttpHeader);

            var response = Client.Execute<User>(_restRequest);

            JavaScriptSerializer deserial = new JavaScriptSerializer();

            var JSONObj = JsonConvert.DeserializeObject<User>(response.Content);

            return JSONObj.access_token;
        }

    }
}
