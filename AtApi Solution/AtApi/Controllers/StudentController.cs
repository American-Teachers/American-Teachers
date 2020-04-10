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
        private readonly IFactory<StudentModel> _factory;
        public StudentController(IFactory<StudentModel> factory)
        {
            _factory = factory;
        }
        // GET: api/Student
        [HttpGet]
        [Route("")]
        public IEnumerable<StudentModel> GetAll()
        {
            return _factory.GetAll();
        }
 

        // GET: api/Student/5
        [HttpGet]
        [Route("{id}")]
        public StudentModel Get(int id)
        {
            return _factory.GetOne(id);
        }

        // POST: api/Student
        [HttpPost]
        [Route("")]
        public StudentModel Post([FromBody] StudentModel model)
        {
            return _factory.Update(model);
        }

        // PUT: api/Student/5
        [HttpPut]
        [Route("{id}")]
        public StudentModel Put(int id, [FromBody] StudentModel model)
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