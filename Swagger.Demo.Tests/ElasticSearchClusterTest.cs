using Nest;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swagger.Demo.Tests
{
    [TestFixture]
    class ElasticSearchClusterTest
    {
        public ElasticClient client;

        [SetUp]
        public void Setup()
        {
            try
            {
                var uriString = "http://localhost:9200";
                var searchBoxUri = new Uri(uriString);
                var settings = new ConnectionSettings(searchBoxUri);
                settings.DefaultIndex("product");
                client = new ElasticClient(settings);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Test]
        public void CheckClusterHealthIsValid()
        {
            var response = client.ClusterHealth();
            Assert.That(response.IsValid, Is.True);

            Console.WriteLine(response.IsValid);
        }
    }
}
