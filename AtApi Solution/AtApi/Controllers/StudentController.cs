using System.Collections.Generic;
using AtApi.Model;
using AtApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace AtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IFactory<Student> _factory;
        public StudentController(IFactory<Student> factory)
        {
            _factory = factory;
        }
        // GET: api/Student
        [HttpGet]
        [Route("")]
        public IEnumerable<Student> GetAll()
        {
            return _factory.GetAll();
        }
 

        // GET: api/Student/5
        [HttpGet]
        [Route("{id}")]
        public Student Get(int id)
        {
            return _factory.GetOne(id);
        }

        // POST: api/Student
        [HttpPost]
        [Route("")]
        public Student Post([FromBody] Student model)
        {
            return _factory.Update(model);
        }

        // PUT: api/Student/5
        [HttpPut]
        [Route("{id}")]
        public Student Put(int id, [FromBody] Student model)
        {
            return _factory.Create(model);
        }

        // DELETE: api/Student/5
        [HttpDelete()]
        [Route("{id}")]
        public void Delete(int id)
        {
            _factory.Delete(id);
        }
    }
}