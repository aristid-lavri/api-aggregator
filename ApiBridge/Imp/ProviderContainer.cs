﻿using ApiBridge.ApiBuilder;
using ApiBridge.Model;
using System.Collections.Generic;

namespace ApiBridge.Imp
{
    public class ProviderContainer
    {
        private static readonly IDictionary<string, ApiService> _dictionary = new Dictionary<string, ApiService>();

        public static void RegisterAPI(IApiServiceBuilder api)
        {
            var service = api.Build();
            _dictionary.Add(service.Name, service);
        }

        public static ApiService ResolveAPI(string serviceName)
        {
            return _dictionary[serviceName];
        }
    }
}
