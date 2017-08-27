using AMaaS.Core.Sdk.Configuration;
using System;
using Xunit;

namespace AMaaS.Core.Sdk.Tests
{
    public class ConfigurationTests
    {
        [Fact]
        public void TestConfiguration()
        {
            var config = new AMaaSConfigDev("v1.0");
            Assert.NotNull(config);
        }
    }
}
