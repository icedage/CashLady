using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.WebAPI.Scenarios.Helpers
{
    public class ListA
    {
        public string A { get; set; }

        public string B { get; set; }
    }
   
    public class HttpRequestWrapper : HttpRequestDecorator
    {
        public HttpRequestWrapper(RestSharpComponent component, string resource, Method method)
            : base(component)
        {
            component.Client = new RestClient(resource);
            component.Request.Method = method;
        }

        public HttpRequestWrapper(RestSharpComponent component)
            : base(component)
        { }

        public void AddHeader(List<ListA> headers)
        {
            foreach (var header in headers)
            {
                component.Request.AddHeader(header.A,header.B);
            }
        }

        public void Post(string json)
        {
            component.Request.AddParameter("text/json", json, ParameterType.RequestBody);
        }

        public T Execute<T>() where T : class
        {
            var jsonDeserializer = new JsonDeserializer();
            var response = component.Client.Execute(component.Request);
            return jsonDeserializer.Deserialize<T>(response);
        }

        public int Execute()// where T : class
        {
            var jsonDeserializer = new JsonDeserializer();
            //var response = await component.Client.ExecuteAsync<User>(component.Client);
            var response =component.Client.Execute(component.Request);
            return jsonDeserializer.Deserialize<int>(response);
        }
    }
}
