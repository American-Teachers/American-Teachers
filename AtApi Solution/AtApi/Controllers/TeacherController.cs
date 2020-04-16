using AtApi.Model;
using AtApi.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AtApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly IFactory<Teacher> _factory;

        public TeacherController(IFactory<Teacher> factory)
        {
            _factory = factory;
        }


        // GET: api/Teacher
        [HttpGet]
        [Route("")]
        public IEnumerable<Teacher> GetAll()
        {
            return _factory.GetAll();
        }

        // GET: api/Teacher/5
        [HttpGet()]
        [Route("{id}")]
        public Teacher Get(int id)
        {
            return _factory.GetOne(id);
        }

        // POST: api/Teacher
        [HttpPost]
        [Route("")]
        public Teacher Post([FromBody] Teacher model)
        {
            return _factory.Update(model);
        }

        // PUT: api/Teacher/5
        [HttpPut]
        [Route("{id}")]
        public Teacher Put(int id, [FromBody] Teacher teacher)
        {
            return _factory.Create(teacher);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete()]
        [Route("{id}")]
        public void Delete(int id)
        {
            _factory.Delete(id);
        }
    }
}
