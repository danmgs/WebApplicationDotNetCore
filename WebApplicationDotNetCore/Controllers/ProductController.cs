using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Demo.Core;
using Api.Demo.Core.Interfaces;
using Api.Demo.Models;
using log4net;
using log4net.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApplicationDotNetCore.Models.Config;

namespace WebApplicationDotNetCore.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProductController : Controller
    {
        private readonly IOptions<ElasticSearchSettings> _elasticSearchSettings;
        private readonly ISearchClient<Product> _searchClient;
        private readonly IManagerClient _managerClient;

        private static readonly ILog log = LogManager.GetLogger(typeof(ProductController));

        public ProductController(ISearchClient<Product> searchClient, IManagerClient managerClient, IOptions<ElasticSearchSettings> elasticSearchSettings)
        {
            _searchClient = searchClient;

            _elasticSearchSettings = elasticSearchSettings;

            _managerClient = managerClient;
        }

        // GET: api/product/search ??=> /api/product/wine
        //[HttpGet("api/[controller]/[action]/{value}")]
        [Route("Search/{value}")]
        public IEnumerable<Product> Search(string value)
        {
            log.Info($"oh yeah value = {value}");
            var res = _searchClient.Search(value, 1, 1000, x => x.Name);
            return res;
        }

        // GET: api/product
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/product/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/product
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
