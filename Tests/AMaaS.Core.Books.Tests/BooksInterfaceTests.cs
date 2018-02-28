using AMaaS.Core.Sdk;
using AMaaS.Core.Sdk.Extensions;
using AMaaS.Core.Sdk.Books;
using AMaaS.Core.Sdk.Configuration;
using Autofac;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AMaaS.Core.Books.Tests
{
    public class BookInterfaceTests
    {
        private IContainer _container;

        public BookInterfaceTests()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(new AMaaSConfigDefault("v1.0")).As<IAMaaSConfiguration>().SingleInstance();
            builder.RegisterType<AMaaSSession>().SingleInstance();
            builder.RegisterType<BooksInterface>().As<IBooksInterface>().InstancePerLifetimeScope();

            _container = builder.Build();
        }

        [Fact]
        public async Task TestSearchBooks()
        {
            var booksInterface = _container.Resolve<IBooksInterface>();
            var results = await booksInterface.SearchBooks(103, bookIds: new List<string> { "STRESS1", "STRESS2" });
            Assert.False(results.IsNullOrEmpty());

            results = await booksInterface.SearchBooks(103, partyIds: new List<string> { "PNL_STRESS" });
        }
    }
}
