using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.WebAPI.Scenarios.Helpers
{
    public class RestSharpWrapper
    {
        private IRestRequest Request { get; set; }
        private IRestClient Client { get; set; }

        public RestSharpWrapper(string url, string resourse)
        {
            Client = new RestClient(url);
            Request = new RestRequest(resourse);
        }

        public void AddJsonBody(object entity)
        {
            Request.AddJsonBody(entity);
        }

        public void AddBody(object entity)
        {
            Request.AddBody(entity);
        }

        public T Execute<T>() where T : class, new()
        {
            var jsonDeserializer = new JsonDeserializer();
            var response = Client.Execute<T>(Request);
            return jsonDeserializer.Deserialize<T>(response);
        }
    }
}
