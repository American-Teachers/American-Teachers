using System.Collections.Generic;
using AtApi.Model;
using AtApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace AtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {

        private readonly IFactory<ClassModel> _factory;
        public ClassController(IFactory<ClassModel> factory)
        {
            _factory = factory;
        }
        // GET: api/Class
        [HttpGet]
        [Route("")]
        public IEnumerable<ClassModel> GetAll()
        {
            return _factory.GetAll();
        }

        // GET: api/Class/5
        [HttpGet()]
        [Route("{id}")]
        public ClassModel Get(int id)
        {
            return _factory.GetOne(id);
        }

        // POST: api/Class
        [HttpPost]
        [Route("")]
        public ClassModel Post([FromBody] ClassModel model)
        {
            return _factory.Update(model);
        }

        // PUT: api/Class/5
        [HttpPut]
        [Route("{id}")]
        public ClassModel Put(int id, [FromBody] ClassModel model)
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