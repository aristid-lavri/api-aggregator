using System.Net.Http;
using System.Threading.Tasks;

namespace ApiBridge.Interfaces
{
    public interface IProvider
    {
        Task<HttpResponseMessage> ExecuteApiAsync(string targetEndPoint, string apiName = "risk", object obj = null);
    }
}
