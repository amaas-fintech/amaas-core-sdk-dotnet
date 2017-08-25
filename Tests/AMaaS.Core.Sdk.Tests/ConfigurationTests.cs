using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AMaaS.Core.Sdk.Configuration;

namespace AMaaS.Core.Sdk.Tests
{
    [TestClass]
    public class ConfigurationTests
    {
        [TestMethod]
        public void TestConfiguration()
        {
            var config = new AMaaSConfigDev("v1.0");
        }
    }
}
