using AMaaS.Core.Sdk.Configuration;
using AMaaS.Core.Sdk.Extensions;
using Autofac;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AMaaS.Core.Sdk.Transactions.Tests
{
    public class TransactionsInterfaceTests
    {
        private IContainer _container;

        public TransactionsInterfaceTests()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(new AMaaSConfigDev("v1.0")).As<IAMaaSConfiguration>().SingleInstance();
            builder.RegisterType<AMaaSSession>().SingleInstance();
            builder.RegisterType<TransactionsInterface>().As<ITransactionsInterface>().InstancePerLifetimeScope();

            _container = builder.Build();
        }

        [Fact]
        public async Task TestSearchTransactions()
        {
            var transactionInterface = _container.Resolve<ITransactionsInterface>();
            var results = await transactionInterface.SearchTransactions(assetManagerIds: new List<int> { 1 });

            Assert.False(results.IsNullOrEmpty());
        }

        [Fact]
        public async Task TestSearchPositions()
        {
            var transactionInterface = _container.Resolve<ITransactionsInterface>();
            var results = await transactionInterface.SearchPositions(assetManagerIds: new List<int> { 1 });

            Assert.False(results.IsNullOrEmpty());
        }
    }
}
