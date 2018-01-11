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


        // GET: api/product/search/value
        /// <summary>
        /// Get a list of products matching the search term
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/product/search/wine
        ///
        /// </remarks>
        ///// <param name="value">The search Terme</param>
        ///// <returns>Products matching the search term</returns>
        [Route("search/{value}")]
        public IEnumerable<Product> Search(string value)
        {
            var res = _searchClient.Search(value, 1, 1000, x => x.Name);
            return res;
        }

        // GET: api/product
        /// <summary>
        /// Get all the products
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/product/search
        ///
        /// </remarks>
        ///// <returns>All the products</returns>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return Search(null);
        }

        // GET: api/product/1
        /// <summary>
        /// Get the product by the given id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/product/1
        ///
        /// </remarks>
        ///// <param name="value">The product id</param>
        ///// <returns>Product identified by the given id</returns>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var res = _searchClient.Get(id.ToString());
            return Json(res);
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
