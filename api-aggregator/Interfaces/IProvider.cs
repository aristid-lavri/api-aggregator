using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace apiaggregator.Interfaces
{
    public interface IProvider
    {
        Task<HttpResponseMessage> ExecuteApiAsync(string targetEndPoint, string apiName, Dictionary<string, object> obj = null);
    }
}
