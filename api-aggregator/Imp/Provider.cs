using apiaggregator.Interfaces;
using apiaggregator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace apiaggregator.Imp
{
    public sealed class Provider : IProvider
    {
        public async Task<HttpResponseMessage> ExecuteApiAsync(string targetEndPoint, string apiName, Dictionary<string, object> parameters = null)
        {
            var api = ProviderContainer.ResolveAPI(apiName);
            var client = new HttpClient();
            var request = new HttpRequestMessage();
            var target = api.EndPoints.Where(e => e.Name == targetEndPoint).SingleOrDefault();

            StringBuilder targetUrl = new StringBuilder();
            targetUrl.Append(target.RelativeUrl);

            switch (target.Method)
            {
                case ApiMethod.GET:
                    {
                        request.Method = HttpMethod.Get;
                    }
                    break;
                case ApiMethod.POST:
                    {
                        request.Method = HttpMethod.Post;
                    }
                    break;
                case ApiMethod.PUT:
                    break;
                case ApiMethod.DELETE:
                    break;
                default:
                    break;
            }

            if (parameters == null)
            {
                return await client.SendAsync(request);
            }

            bool isQueryFormated = false;
            foreach (var item in parameters)
            {
                var endPointParameter = target.Parameters.SingleOrDefault(p => p.Key == item.Key);
                if (endPointParameter.ParameterType == ParameterType.Query)
                {
                    if (!isQueryFormated)
                    {
                        targetUrl.Append("?");
                        isQueryFormated = true;
                    }

                    targetUrl.Append(item.Key);
                    targetUrl.Append("=");
                    targetUrl.Append(item.Value);
                    targetUrl.Append("&");
                }
                else if (endPointParameter.ParameterType == ParameterType.Url)
                {
                    targetUrl.Append("/");
                    targetUrl.Append(item.Value);
                    targetUrl.Append("/");
                }

                targetUrl.Remove(targetUrl.Length - 1, 1);

                if (endPointParameter.ParameterType == ParameterType.Dictionary)
                {
                    var _keyValue = new List<KeyValuePair<string, string>>();
                    _keyValue.AddRange((List<KeyValuePair<string, string>>)item.Value);

                    var _requestContent = new FormUrlEncodedContent(_keyValue);
                    request.Content = _requestContent;
                }
                else if (endPointParameter.ParameterType == ParameterType.Json)
                {
                    var _jsonContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(item.Value),
                        Encoding.UTF8, "application/json");

                    request.Content = _jsonContent;
                }
                else if (endPointParameter.ParameterType == ParameterType.TextPlain)
                {
                    var _jsonContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(item.Value),
                        Encoding.UTF8, "text/plain");

                    request.Content = _jsonContent;
                }
                else if (endPointParameter.ParameterType == ParameterType.TextCsv)
                {
                    var _jsonContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(item.Value),
                        Encoding.UTF8, "text/Csv");

                    request.Content = _jsonContent;
                }
            }

            request.RequestUri = new Uri(api.BaseUrl, targetUrl.ToString());
            return await client.SendAsync(request);
        }
    }




}
