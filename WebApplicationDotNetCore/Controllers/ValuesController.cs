using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDotNetCore.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using log4net;

namespace WebApplicationDotNetCore.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ValuesController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ValuesController));

        List<Person> PersonList = new List<Person>
        {
            new Person() { Id = 1, Age = 10, Name = "Helen" },
            new Person() { Id = 2, Age = 22, Name = "Max" }
        };

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        /// <summary>
        /// Get a value
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/values/5
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>A value</returns>
        /// <response code="200">Returns a value</response>
        /// <response code="400">If the value is null</response>            
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public JsonResult Get(int id)
        {
            return Json("value" + id);
        }

        // POST api/values
        [HttpPost]
        /// <summary>
        /// POST a value
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/values
        ///     {
        ///        "value": "foobar",
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>          
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // GET api/values/1/helen
        /// <summary>
        /// Get a person matching given an id and name in input.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/values/1/helen
        ///
        /// </remarks>
        ///// <param name="id"></param>
        ///// /// <param name="name"></param>
        ///// <returns>A person</returns>
        ///// <response code="200">Returns a person</response>
        ///// <response code="400">If the value is null</response>            
        [HttpGet("{id}/{name}")]
        //[Route("values/person/")]
        //[ProducesResponseType(typeof(string), 200)]
        //[ProducesResponseType(typeof(string), 400)]
        [SwaggerResponse((int)System.Net.HttpStatusCode.OK, Type = typeof(Person))]
        public ActionResult GetPerson(int id, string name)
        {
            var pers = PersonList.FirstOrDefault(p => p.Id.Equals(id) && p.Name.ToUpper().Equals(name.ToUpper()));
            return Json(pers);
        }
    }
}
