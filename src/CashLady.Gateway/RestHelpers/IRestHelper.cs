using CashLady.Contracts.WebApp;
using System.Net.Http;
using System.Threading.Tasks;

namespace CashLady.Gateway.RestHelpers
{
    public interface IRestHelper
    {
        Task<RestResponse> DoPostRequest(StringContent data, string suffix);

        RestResponse DoGetRequest();
    }
}
