using apiaggregator.Model;
using System;

namespace apiaggregator.ApiBuilder
{
    public interface IApiServiceBuilder
    {
        IApiServiceBuilder ConfigServeur(string name, Uri baseUrl, int? port);
        IApiServiceBuilder AddEndPoint(EndPoint endPoint);
        ApiService Build();
    }
}
