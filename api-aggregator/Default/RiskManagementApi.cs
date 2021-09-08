using System;

namespace apiaggregator.Default
{
    public sealed class RiskManagementApi
    {
        public static ApiBuilder.IApiServiceBuilder Build()
        {
            return new ApiBuilder.ApiServiceBuilder()
                .ConfigServeur("Risk", new Uri("https://localhost:44356/"), null)
                .AddEndPoint(new apiaggregator.Model.EndPoint
                {
                    Name = "get-weatherforecast",
                    RelativeUrl = "weatherforecast",
                    Method = apiaggregator.Model.ApiMethod.GET,
                    ParameterType = apiaggregator.Model.ParameterType.Query
                })
                .AddEndPoint(new apiaggregator.Model.EndPoint
                {
                    Name = "post-weatherforecast",
                    RelativeUrl = "weatherforecast",
                    Method = apiaggregator.Model.ApiMethod.POST,
                    ParameterType = apiaggregator.Model.ParameterType.Dictionary
                });
        }
    }
}
