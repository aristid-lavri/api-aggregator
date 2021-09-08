using System;

namespace apiaggregator.Default
{
    public class FakeJsonTestApi
    {
        ///posts
        public static ApiBuilder.IApiServiceBuilder Build()
        {
            return new ApiBuilder.ApiServiceBuilder()
                .ConfigServeur("Json", new Uri("https://jsonplaceholder.typicode.com/"), null)
                .AddEndPoint(new apiaggregator.Model.EndPoint
                {
                    Name = "get-posts",
                    RelativeUrl = "posts",
                    Method = apiaggregator.Model.ApiMethod.GET,
                    ParameterType = apiaggregator.Model.ParameterType.None
                });
        }
    }
}
