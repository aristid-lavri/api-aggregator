using System;

namespace ApiBridge.Default
{
    public class FakeJsonTestApi
    {
        ///posts
        public static ApiBuilder.IApiServiceBuilder Build()
        {
            return new ApiBuilder.ApiServiceBuilder()
                .ConfigServeur("Json", new Uri("https://jsonplaceholder.typicode.com/"), null)
                .AddEndPoint(new ApiBridge.Model.EndPoint
                {
                    Name = "get-posts",
                    RelativeUrl = "posts",
                    Method = ApiBridge.Model.ApiMethod.GET,
                    ParameterType = ApiBridge.Model.ParameterType.None
                });
        }
    }
}
