using AtApi.Model;
using AtApi.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AtApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {

        private readonly IFactory<School> _factory;
        public SchoolController(IFactory<School> factory)
        {
            _factory = factory;
        }
        // GET: api/School
        [HttpGet]
        [Route("")]
        public IEnumerable<School> GetAll()
        {
            return _factory.GetAll();
        }

        // GET: api/School/5
        [HttpGet()]
        [Route("{id}")]
        public School GetSchool(int id)
        {
            return _factory.GetOne(id);
        }

        // POST: api/School
        [HttpPost]
        [Route("")]
        public School PostSchool([FromBody] School model)
        {
            return _factory.Update(model);
        }

        // PUT: api/School/5
        [HttpPut]
        [Route("{id}")]
        public School PutSchoolModel(int id, [FromBody] School model)
        {
            return _factory.Create(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _factory.Delete(id);
        }
    }
}