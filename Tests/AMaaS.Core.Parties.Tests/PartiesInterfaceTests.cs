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
    public class PartiesInterfaceTests
    {
        private IContainer _container;

        public PartiesInterfaceTests()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(new AMaaSConfigDefault("v1.0")).As<IAMaaSConfiguration>().SingleInstance();
            builder.RegisterType<AMaaSSession>().SingleInstance();
            builder.RegisterType<PartiesInterface>().As<IPartiesInterface>().InstancePerLifetimeScope();

            _container = builder.Build();
        }

        [Fact]
        public async Task TestSearchParties()
        {
            var partiesInterface = _container.Resolve<IPartiesInterface>();
            var results = await partiesInterface.SearchParties(103);

            Assert.False(results.IsNullOrEmpty());
        }
    }
}
