using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nest;

namespace Swagger.Demo.Tests
{
    [TestClass]
    public class ElasticSearchClusterTest
    {
        public static ElasticClient client;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
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

        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void CheckClusterHealthIsValid()
        {
            var response = client.ClusterHealth();
            Assert.IsTrue(response.IsValid);

            Console.WriteLine(response.IsValid);
        }

        [TestMethod]
        public void SearchValid()
        {
            //var response = client.IndexExists(new Indices());
            //Assert.IsTrue(response.IsValid);

            //Console.WriteLine(response.IsValid);
        }

    }
}



/*

[AssemblyInitialize()]
public static void AssemblyInit(TestContext context) { }

[ClassInitialize()]
public static void ClassInit(TestContext context) { }

[TestInitialize()]
public void Initialize() { }

[TestCleanup()]
public void Cleanup() { }

[ClassCleanup()]
public static void ClassCleanup() { }

[AssemblyCleanup()]
public static void AssemblyCleanup() { }

    */
