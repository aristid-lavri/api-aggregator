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

            var result = provider.ExecuteApiAsync( "get-posts", "Json").Result;
            var data = result.Content.ReadAsStringAsync();
            Console.WriteLine(result.StatusCode);
            Console.WriteLine(data.Result);

            Console.ReadLine();
        }
    }
}
