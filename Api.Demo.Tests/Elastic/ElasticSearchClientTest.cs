using Api.Demo.Core;
using Api.Demo.Core.Interfaces;
using Api.Demo.Models;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Demo.Tests.Elastic
{
    [TestFixture]
    public class ElasticSearchClientTest
    {
        public ISearchClient<Product> _client;

        [SetUp]
        public void Setup()
        {
            try
            {
                _client = new ElasticSearchClient<Product>(AppSettings.Es.Endpoint.Url, AppSettings.Es.Index.Name);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Test]
        public void SearchContainsResults()
        {
            var actual = _client.Search("wine", 1, 1000, x => x.Name);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Not.Empty);
            Assert.That(actual.Any(p => p.Tags.Any()), Is.True);
        }

        [Test]
        public void SearchAsyncContainsResults()
        {
            var task = _client.SearchAsync("wine", 1, 1000, x => x.Name);
            Task.WaitAny(task);

            var actual = task.Result;

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Not.Empty);
            Assert.That(actual.Any(p => p.Tags.Any()), Is.True);
        }


    }
}
