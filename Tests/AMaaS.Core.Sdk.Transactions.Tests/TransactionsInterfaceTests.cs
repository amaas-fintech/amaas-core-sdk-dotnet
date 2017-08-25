using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using AMaaS.Core.Sdk.Configuration;
using AMaaS.Core.Sdk.Extensions;
using System.Threading.Tasks;

namespace AMaaS.Core.Sdk.Transactions.Tests
{
    /// <summary>
    /// Summary description for TransactionsInterfaceTests
    /// </summary>
    [TestClass]
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

        [TestMethod]
        public async Task TestSearchTransactions()
        {
            var transactionInterface = _container.Resolve<ITransactionsInterface>();
            var results = await transactionInterface.SearchTransactions(assetManagerIds: new List<int> { 1 });

            Assert.IsFalse(results.IsNullOrEmpty());
        }

        [TestMethod]
        public async Task TestSearchPositions()
        {
            var transactionInterface = _container.Resolve<ITransactionsInterface>();
            var results = await transactionInterface.SearchPositions(assetManagerIds: new List<int> { 1 });

            Assert.IsFalse(results.IsNullOrEmpty());
        }
    }
}
