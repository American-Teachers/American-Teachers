using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        // GET: api/Class
        [HttpGet]
        [Route("")]
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Class/5
        [HttpGet()]
        [Route("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Class
        [HttpPost]
        [Route("")]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Class/5
        [HttpPut]
        [Route("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
        }
    }
}