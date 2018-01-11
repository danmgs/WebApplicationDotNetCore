using Api.Demo.Core;
using Api.Demo.Core.Interfaces;
using NUnit.Framework;
using System;

namespace Api.Demo.Tests.Elastic
{
    [TestFixture]
    public class ElasticMonitorClientTest
    {
        public IManagerClient _client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            try
            {
                _client = new ElasticManagerClient(AppSettings.Es.Endpoint.Url, AppSettings.Es.Index.Name);                
            }
            catch (Exception)
            {
                throw;
            }
        }

        [SetUp]
        public void SetUp()
        {
            try
            {
                if (_client.IndexExists("dummy"))
                    _client.DeleteIndex("dummy");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Test]
        public void CheckClusterHealthIsValid()
        {
            var actual = _client.CheckClusterHealth();
            Assert.That(actual, Is.True);
        }

        [Test]
        public void CheckIndexExists()
        {
            var actual = _client.IndexExists(AppSettings.Es.Index.Name);
            Assert.That(actual, Is.True);
        }

        [Test]
        public void CreateIndex()
        {
            var actual = _client.CreateIndex("dummy");

            Assert.That(actual, Is.True);
        }

        [Test]
        public void DeleteIndex()
        {
            if (_client.CreateIndex("dummy"))
            {
                var actual = _client.DeleteIndex("dummy");

                Assert.That(actual, Is.True);
            }
            else throw new InvalidOperationException("Can not create index");
        }

        [Test]
        public void CreateIndexTwiceReturnsFalse()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_client.CreateIndex("dummy"), Is.True);
                Assert.That(_client.CreateIndex("dummy"), Is.False);
            });
            
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            try
            {
                _client = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                if (_client.IndexExists("dummy"))
                    _client.DeleteIndex("dummy");
            }
            catch (Exception)
            {
                throw;
            }
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
