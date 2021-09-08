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
        public async Task<HttpResponseMessage> ExecuteApiAsync(string targetEndPoint, string apiName = "risk", object parameter = null)
        {
            var api = ProviderContainer.ResolveAPI(apiName);
            var client = new HttpClient();
            var request = new HttpRequestMessage();
            var target = api.EndPoints.Where(e => e.Name == targetEndPoint).SingleOrDefault();

            switch (target.Method)
            {
                case ApiMethod.GET:
                    {
                        StringBuilder targetUrl = new StringBuilder();
                        targetUrl.Append(target.RelativeUrl);

                        if (parameter != null)
                        {
                            if (target.ParameterType == ParameterType.Query)
                            {

                                targetUrl.Append("?");

                                foreach (var item in (Dictionary<string, string>)parameter)
                                {
                                    targetUrl.Append(item.Key);
                                    targetUrl.Append("=");
                                    targetUrl.Append(item.Value);
                                    targetUrl.Append("&");
                                }
                                targetUrl.Remove(targetUrl.Length - 1, 1);
                            }

                            if (target.ParameterType == ParameterType.Url)
                            {
                                targetUrl.Append("/");

                                foreach (var item in (Dictionary<string, string>)parameter)
                                {
                                    targetUrl.Append(item.Value);
                                    targetUrl.Append("/");
                                }
                                targetUrl.Remove(targetUrl.Length - 1, 1);
                            }
                        }
                        request.Method = HttpMethod.Get; request.RequestUri = new Uri(api.BaseUrl, targetUrl.ToString());
                    }
                    break;
                case ApiMethod.POST:
                    {
                        if (target.ParameterType == ParameterType.Dictionary)
                        {
                            var _keyValue = new List<KeyValuePair<string, string>>();

                            foreach (var item in (Dictionary<string, object>)parameter)
                            {
                                _keyValue.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                            }

                            var _requestContent = new FormUrlEncodedContent(_keyValue);
                            request.Content = _requestContent;
                        }

                        if (target.ParameterType == ParameterType.Json)
                        {
                            var _jsonContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(parameter),
                                Encoding.UTF8, "application/json");
                            request.Content = _jsonContent;
                        }

                        request.Method = HttpMethod.Post; request.RequestUri = new Uri(api.BaseUrl, target.RelativeUrl);
                    }
                    break;
                case ApiMethod.PUT:
                    break;
                case ApiMethod.DELETE:
                    break;
                default:
                    break;
            }

            return await client.SendAsync(request);
        }
    }




}
