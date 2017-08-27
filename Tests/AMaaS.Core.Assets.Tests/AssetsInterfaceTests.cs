using AMaaS.Core.Sdk;
using AMaaS.Core.Sdk.Assets;
using AMaaS.Core.Sdk.Configuration;
using AMaaS.Core.Sdk.Extensions;
using Autofac;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AMaaS.Core.Assets.Tests
{
    public class AssetsInterfaceTests
    {
        private IContainer _container;

        public AssetsInterfaceTests()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(new AMaaSConfigDev("v1.0")).As<IAMaaSConfiguration>().SingleInstance();
            builder.RegisterType<AMaaSSession>().SingleInstance();
            builder.RegisterType<AssetsInterface>().As<IAssetsInterface>().InstancePerLifetimeScope();

            _container = builder.Build();
        }

        [Fact]
        public async Task TestSearchAssets()
        {
            var assetsInterface = _container.Resolve<IAssetsInterface>();
            var results = await assetsInterface.SearchAssets(assetManagerIds: new List<int> { 1 }, pageNo: 1, pageSize: 5);

            Assert.False(results.IsNullOrEmpty());
        }
    }
}
