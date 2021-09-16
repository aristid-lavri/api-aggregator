using apiaggregator.Default;
using apiaggregator.Imp;
using System;
using System.Collections.Generic;

namespace apiaggregator.sample
{
    class Program
    {
        static void Main(string[] args)
        {
            ProviderContainer.RegisterAPI(FakeJsonTestApi.Build());
            Provider provider = new Provider();

            var weather = @"{ Date = DateTime.Now.AddDays(1), TemperatureC = 55, Summary = \""test api builder\"" }";

            var parameters = new Dictionary<string, object>();
            parameters.Add("id", "lavri2021");
            parameters.Add("weather", weather);

            var result = provider.ExecuteApiAsync("add-data", "Json", parameters).Result;
            var data = result.Content.ReadAsStringAsync();
            Console.WriteLine(result.StatusCode);
            Console.WriteLine(data.Result);

            Console.ReadLine();
        }
    }
}
