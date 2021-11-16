using apiaggregator.Model;
using System;
using System.Collections.Generic;

namespace apiaggregator.Default
{
    public class FakeJsonTestApi
    {
        ///posts
        public static ApiBuilder.IApiServiceBuilder Build()
        {
            return new ApiBuilder.ApiServiceBuilder()
                //.ConfigServeur("Json", new Uri("https://jsonplaceholder.typicode.com/"), null)
                .ConfigServeur("Json", new Uri("https://localhost:44356/"), null)
                .AddEndPoint(new apiaggregator.Model.EndPoint
                {
                    Name = "get-posts",
                    RelativeUrl = "comments",
                    Method = apiaggregator.Model.ApiMethod.GET,
                    Parameters = new List<EndPointParameter>()
                    {
                        new EndPointParameter
                        {
                            Key = "postId",
                            ParameterType = ParameterType.Query
                        }
                    }
                })
                .AddEndPoint(new apiaggregator.Model.EndPoint
                {
                    Name = "add-data",
                    RelativeUrl = "weatherforecast",
                    Method = apiaggregator.Model.ApiMethod.POST,
                    Parameters = new List<EndPointParameter>()
                    {
                        new EndPointParameter
                        {
                            Key = "id",
                            ParameterType = ParameterType.Query
                        },
                        new EndPointParameter
                        {
                            Key = "test",
                            ParameterType = ParameterType.Query
                        },
                        new EndPointParameter
                        {
                            Key = "weather",
                            ParameterType = ParameterType.TextPlain
                        }
                    }
                });
        }
    }
}
