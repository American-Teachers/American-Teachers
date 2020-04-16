using AtApi.Model;
using AtApi.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IFactory<Parent> _factory;
        public ParentController(IFactory<Parent> factory)
        {
            _factory = factory;
        }
        // GET: api/Parent
        [HttpGet]
        [Route("")]
        public IEnumerable<Parent> GetAll()
        {
            return _factory.GetAll();
        }


        // GET: api/Parent/5
        [HttpGet]
        [Route("{id}")]
        public Parent Get(int id)
        {
            return _factory.GetOne(id);
        }

        // POST: api/Parent
        [HttpPost]
        [Route("")]
        public Parent Post([FromBody] Parent model)
        {
            return _factory.Update(model);
        }

        // PUT: api/Parent/5
        [HttpPut]
        [Route("{id}")]
        public Parent Put(int id, [FromBody] Parent model)
        {
            return _factory.Create(model);
        }

        // DELETE: api/Parent/5
        [HttpDelete()]
        [Route("{id}")]
        public void Delete(int id)
        {
            _factory.Delete(id);
        }
    }
}