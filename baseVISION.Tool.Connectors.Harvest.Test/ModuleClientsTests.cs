using Microsoft.VisualStudio.TestTools.UnitTesting;
using baseVISION.Tool.Connectors.Harvest;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using baseVISION.Tool.Connectors.Harvest.Test;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Concurrent;

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

        [TestMethod()]
        public async Task List_RetriesOnRateLimit()
        {
            const int parallelRequests = 3;
            using var server = new RateLimitedTestServer(parallelRequests);
            var warnings = new ConcurrentBag<RetryWarningEventArgs>();

            var callTasks = Enumerable.Range(0, parallelRequests).Select(_ => Task.Run(() =>
            {
                var client = new HarvestClient("account", "token", server.BaseUrl);
                client.RetryWarning += (_, args) => warnings.Add(args);

                var result = client.Clients.List(maxRetries: 2);
                Assert.IsTrue(result.Clients.Count > 0);
            })).ToArray();

            await Task.WhenAll(callTasks);
            Assert.AreEqual(parallelRequests, warnings.Count);
        }
    }
}