using CashLady.Contracts.WebApp;
using System.Net.Http;
using System.Threading.Tasks;

namespace CashLady.Gateway.RestHelpers
{
    public interface IRestHelper
    {
        Task<RestResponse> DoPostRequest(string data, string suffix);

        RestResponse DoGetRequest();
    }
}
