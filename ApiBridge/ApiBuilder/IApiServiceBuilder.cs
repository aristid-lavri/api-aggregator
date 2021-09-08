using ApiBridge.Model;
using System;

namespace ApiBridge.ApiBuilder
{
    public interface IApiServiceBuilder
    {
        IApiServiceBuilder ConfigServeur(string name, Uri baseUrl, int? port);
        IApiServiceBuilder AddEndPoint(EndPoint endPoint);
        ApiService Build();
    }
}
