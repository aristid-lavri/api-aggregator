using apiaggregator.Default;
using apiaggregator.Imp;
using System;

namespace apiaggregator.sample
{
    class Program
    {
        static void Main(string[] args)
        {
            ProviderContainer.RegisterAPI(FakeJsonTestApi.Build());
            Provider provider = new Provider();

            var result = provider.ExecuteApiAsync("get-posts", "Json").Result;
            var data = result.Content.ReadAsStringAsync();
            Console.WriteLine(result.StatusCode);
            Console.WriteLine(data.Result);

            Console.ReadLine();
        }
    }
}
