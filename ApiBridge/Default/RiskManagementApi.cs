using System;

namespace ApiBridge.Default
{
    public sealed class RiskManagementApi
    {
        public static ApiBuilder.IApiServiceBuilder Build()
        {
            return new ApiBuilder.ApiServiceBuilder()
                .ConfigServeur("Risk", new Uri("https://localhost:44356/"), null)
                .AddEndPoint(new ApiBridge.Model.EndPoint
                {
                    Name = "get-weatherforecast",
                    RelativeUrl = "weatherforecast",
                    Method = ApiBridge.Model.ApiMethod.GET,
                    ParameterType = ApiBridge.Model.ParameterType.Query
                })
                .AddEndPoint(new ApiBridge.Model.EndPoint
                {
                    Name = "post-weatherforecast",
                    RelativeUrl = "weatherforecast",
                    Method = ApiBridge.Model.ApiMethod.POST,
                    ParameterType = ApiBridge.Model.ParameterType.Dictionary
                });
        }
    }
}
