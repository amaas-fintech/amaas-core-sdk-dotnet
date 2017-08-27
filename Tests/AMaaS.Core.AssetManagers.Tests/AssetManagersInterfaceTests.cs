using AMaaS.Core.Sdk;
using AMaaS.Core.Sdk.AssetManagers;
using AMaaS.Core.Sdk.Configuration;
using AMaaS.Core.Sdk.Constants;
using Autofac;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AMaaS.Core.AssetManagers.Tests
{
    public class AssetManagersInterfaceTests
    {
        private IContainer _container;

        public AssetManagersInterfaceTests()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(new AMaaSConfigDev("v1.0")).As<IAMaaSConfiguration>().SingleInstance();
            builder.RegisterType<AMaaSSession>().SingleInstance();
            builder.RegisterType<AssetManagersInterface>().As<IAssetManagersInterface>().InstancePerLifetimeScope();

            _container = builder.Build();
        }

        [Fact]
        public async Task TestGetUserRelationships()
        {
            var assetManagerInterface = _container.Resolve<IAssetManagersInterface>();
            var userAssetManagerId = await assetManagerInterface.Session?.GetTokenAttribute(CognitoAttributes.AssetManagerId);
            var relationships = await assetManagerInterface.GetUserRelationships(int.Parse(userAssetManagerId));
            Assert.NotNull(relationships);
        }
    }
}
