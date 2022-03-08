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
    public class HarvestClientTests
    {
        public HarvestClient harvestClient;
        public void Initialize()
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddUserSecrets<HarvestClientTests>()
            .Build();

            UserConfig uc = config.Get<UserConfig>();

            harvestClient = new HarvestClient(uc.harvestAccountId,uc.harvestPersonalAccessToken);
        }
        [TestMethod()]
        public void HarvestClientTest_Success()
        {
            Initialize();
            
        }

        [TestMethod()]
        public void HarvestClientTest_Fail()
        {
            var harvestClient = new HarvestClient("8587589", "aisdgoisgduasduhapdh");

        }
    }
}