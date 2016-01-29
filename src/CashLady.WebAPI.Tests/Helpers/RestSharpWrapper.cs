using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashLady.WebAPI.Tests.Helpers;

namespace CashLady.WebAPI.Tests.Helpers
{
    public class RestSharpWrapper : RestSharpComponent 
    {
        private IDictionary<string, string> _dictionary;
        
        public RestSharpWrapper(string url, string resourse, IDictionary<string, string> headers)
        {
            Client = new RestClient(url);
            Request = new RestRequest(resourse);
            _dictionary = new Dictionary<string, string>();
        }

        public void AddHeader()
        {
            foreach(KeyValuePair<string,string> item in _dictionary)
            {
                Request.AddHeader(item.Key, item.Value);
            }
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
            var jsonDeserializer= new JsonDeserializer();
            var response=Client.Execute<T>(Request);
            return jsonDeserializer.Deserialize<T>(response);
        }
    }
}
