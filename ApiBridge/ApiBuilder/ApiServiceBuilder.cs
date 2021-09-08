using ApiBridge.Model;
using System;

namespace ApiBridge.ApiBuilder
{
    public class ApiServiceBuilder : IApiServiceBuilder
    {
        private readonly ApiService service;
        public ApiServiceBuilder()
        {
            service = new ApiService();
        }

        public IApiServiceBuilder AddEndPoint(EndPoint endPoint)
        {
            service.EndPoints.Add(endPoint);

            return this;
        }

        public IApiServiceBuilder ConfigServeur(string name, Uri baseUrl, int? port)
        {
            service.Name = name;
            service.BaseUrl = baseUrl;
            service.Port = port;

            return this;
        }

        public ApiService Build() => service;
    }
}
