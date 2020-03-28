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
        private readonly IFactory<TeacherModel> _factory;

        public TeacherController(IFactory<TeacherModel> factory)
        {
            _factory = factory;
        }
        

        // GET: api/Teacher
        [HttpGet]
        [Route("")]
        public IEnumerable<TeacherModel> GetAll()
        {
            return _factory.GetAll();
        }

        // GET: api/Teacher/5
        [HttpGet()]
        [Route("{id}")]
        public TeacherModel Get(int id)
        {
            return _factory.GetOne(id);
        }

        // POST: api/Teacher
        [HttpPost]
        [Route("")]
        public TeacherModel Post([FromBody] TeacherModel model)
        {
            return _factory.Update(model);
        }

        // PUT: api/Teacher/5
        [HttpPut]
        [Route("{id}")]
        public TeacherModel Put(int id, [FromBody] TeacherModel teacher)
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
