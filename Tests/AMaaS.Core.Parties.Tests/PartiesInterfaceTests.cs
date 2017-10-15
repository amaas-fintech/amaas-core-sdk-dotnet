using AMaaS.Core.Sdk;
using AMaaS.Core.Sdk.Parties;
using AMaaS.Core.Sdk.Configuration;
using AMaaS.Core.Sdk.Extensions;
using Autofac;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AMaaS.Core.Parties.Tests
{
    public class AssetsInterfaceTests
    {
        private IContainer _container;

        public AssetsInterfaceTests()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(new AMaaSConfigStaging("v1.0")).As<IAMaaSConfiguration>().SingleInstance();
            builder.RegisterType<AMaaSSession>().SingleInstance();
            builder.RegisterType<PartiesInterface>().As<IPartiesInterface>().InstancePerLifetimeScope();

            _container = builder.Build();
        }

        [Fact]
        public async Task TestSearchParties()
        {
            var partiesInterface = _container.Resolve<IPartiesInterface>();
            var results = await partiesInterface.SearchParties(123);

            Assert.False(results.IsNullOrEmpty());
        }
    }
}
