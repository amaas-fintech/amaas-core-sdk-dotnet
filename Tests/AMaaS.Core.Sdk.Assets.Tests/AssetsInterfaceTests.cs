using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Autofac;
using AMaaS.Core.Sdk.Configuration;
using System.Collections.Generic;
using AMaaS.Core.Sdk.Extensions;

namespace AMaaS.Core.Sdk.Assets.Tests
{
    [TestClass]
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

        [TestMethod]
        public async Task TestSearchAssets()
        {
            var assetsInterface = _container.Resolve<IAssetsInterface>();
            var results         = await assetsInterface.SearchAssets(assetManagerIds: new List<int> { 1 }, pageNo: 1, pageSize: 5);

            Assert.IsFalse(results.IsNullOrEmpty());
        }
    }
}
