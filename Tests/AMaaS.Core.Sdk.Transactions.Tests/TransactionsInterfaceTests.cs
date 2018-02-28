using AMaaS.Core.Sdk.Configuration;
using AMaaS.Core.Sdk.Extensions;
using Autofac;
using System.Linq;
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
            builder.RegisterInstance(new AMaaSConfigDefault("v1.0")).As<IAMaaSConfiguration>().SingleInstance();
            builder.RegisterType<AMaaSSession>().SingleInstance();
            builder.RegisterType<TransactionsInterface>().As<ITransactionsInterface>().InstancePerLifetimeScope();

            _container = builder.Build();
        }

        [Fact]
        public async Task TestSearchTransactions()
        {
            var transactionInterface = _container.Resolve<ITransactionsInterface>();
            var results = await transactionInterface.SearchTransactions(103);

            Assert.False(results.IsNullOrEmpty());
        }

        [Fact]
        public async Task TestFieldsSearchTransactions()
        {
            var transactionsInterface = _container.Resolve<ITransactionsInterface>();
            var results = await transactionsInterface.SearchTransactions(assetManagerId: 103,
                                                                         fields: new List<string> { "asset_manager_id,asset_book_id,quantity"},
                                                                         assetBookIds: new List<string> { "STRESS4" },
                                                                         childTypes: new List<string> { "charges" });
            Assert.False(results.IsNullOrEmpty());
            Assert.True(results.First().AssetBookId == "STRESS4");
        }

        [Fact]
        public async Task TestSearchPositions()
        {
            var transactionInterface = _container.Resolve<ITransactionsInterface>();
            var results = await transactionInterface.SearchPositions(103);

            Assert.False(results.IsNullOrEmpty());
        }
    }
}
