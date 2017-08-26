using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using AMaaS.Core.Sdk.Configuration;
using System.Threading.Tasks;
using AMaaS.Core.Sdk.Constants;

namespace AMaaS.Core.Sdk.AssetManagers.Tests
{
    [TestClass]
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

        [TestMethod]
        public async Task TestGetUserRelationships()
        {
            var assetManagerInterface = _container.Resolve<IAssetManagersInterface>();
            var userAssetManagerId    = await assetManagerInterface.Session?.GetTokenAttribute(CognitoAttributes.AssetManagerId);
            var relationships         = await assetManagerInterface.GetUserRelationships(int.Parse(userAssetManagerId));
            Assert.IsNotNull(relationships);
        }
    }
}
