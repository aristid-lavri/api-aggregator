using ApiBridge;
using ApiBridge.ApiBuilder;
using ApiBridge.Default;
using ApiBridge.Imp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestAPIBridge
{
    class Program
    {
        static void Main(string[] args)
        {
            ProviderContainer.RegisterAPI(RiskManagementApi.Build());
            ProviderContainer.RegisterAPI(FakeJsonTestApi.Build());

            Provider provider = new Provider();
            //Dictionary<string,object> parameter = new Dictionary<string, object>();
            //parameter.Add("Date", DateTime.Now.AddDays(1).ToLongDateString());
            //parameter.Add("TemperatureC", 55);
            //parameter.Add("Summary", "test api builder with dico from post api");
            //var parameter = new { Date = DateTime.Now.AddDays(1), TemperatureC = 55, Summary = "test api builder" };

        //var result = provider.ExecuteApiAsync( "post-weatherforecast", "Risk", parameter).Result;
        var result = provider.ExecuteApiAsync( "get-posts", "Json").Result;
            var data = result.Content.ReadAsStringAsync();
            Console.WriteLine(result.StatusCode);
            Console.WriteLine(data.Result);
            Console.ReadLine();
        }
    }
}
