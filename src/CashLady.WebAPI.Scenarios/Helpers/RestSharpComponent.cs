using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.WebAPI.Scenarios.Helpers
{
    public class RestSharpComponent
    {
        public IRestRequest Request { get; set; }

        public IRestClient Client { get; set; }

        public RestSharpComponent()
        {
            var url = ConfigurationManager.AppSettings["AuthorizationServer"];
            Client = new RestClient(url);
            Request = new RestRequest();
        }
    }
}
