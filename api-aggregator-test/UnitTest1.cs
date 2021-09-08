using apiaggregator.Default;
using apiaggregator.Imp;
using apiaggregator.Model;
using NUnit.Framework;

namespace api_aggregator_test
{
    public class Tests
    {
        [Test]
        public void Builder_should_return_api()
        {
            ProviderContainer.RegisterAPI(FakeJsonTestApi.Build());
            var api = ProviderContainer.ResolveAPI("Json");

            Assert.IsInstanceOf(typeof(ApiService), api);
        }
    }
}