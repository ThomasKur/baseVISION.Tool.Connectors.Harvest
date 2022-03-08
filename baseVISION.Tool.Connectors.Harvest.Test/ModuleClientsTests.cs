using Microsoft.VisualStudio.TestTools.UnitTesting;
using baseVISION.Tool.Connectors.Harvest;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using baseVISION.Tool.Connectors.Harvest.Test;

namespace baseVISION.Tool.Connectors.Harvest.Tests
{
    [TestClass()]
    public class ModuleClientsTests
    {
        public HarvestClient harvestClient;
        public void Initialize()
        {
            if (harvestClient is null) {
                var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddUserSecrets<HarvestClientTests>()
                .Build();

                UserConfig uc = config.Get<UserConfig>();

                harvestClient = new HarvestClient(uc.harvestAccountId, uc.harvestPersonalAccessToken);
            }
        }
        [TestMethod()]
        public void ListTest()
        {
            Initialize();
            var clients = harvestClient.Clients.List();
            Assert.IsTrue(clients.Clients.Count > 0);

        }
        [TestMethod()]
        public void ListTest_WithParam()
        {
            Initialize();
            var clients = harvestClient.Clients.List(1,true);
            Assert.IsTrue(clients.Clients.Count > 0);

        }
    }
}