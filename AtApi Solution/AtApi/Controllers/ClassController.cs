using AtApi.Model;
using AtApi.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AtApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {

        private readonly IFactory<Class> _factory;
        public ClassController(IFactory<Class> factory)
        {
            _factory = factory;
        }
        // GET: api/Class
        [HttpGet]
        [Route("")]
        public IEnumerable<Class> GetAll()
        {
            return _factory.GetAll();
        }

        // GET: api/Class/5
        [HttpGet()]
        [Route("{id}")]
        public Class GetClass(int id)
        {
            return _factory.GetOne(id);
        }

        // POST: api/Class
        [HttpPost]
        [Route("")]
        public Class PostClass([FromBody] Class model)
        {
            return _factory.Update(model);
        }

        // PUT: api/Class/5
        [HttpPut]
        [Route("{id}")]
        public Class PutClassModel(int id, [FromBody] Class model)
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