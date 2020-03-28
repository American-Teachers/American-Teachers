using AtApi.Model;
using AtApi.Models;
using AtApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherFactory _teacherFactory;

        public TeacherController(ITeacherFactory teacherFactory)
        {
            _teacherFactory = teacherFactory;
        }
        

        // GET: api/Teacher
        [HttpGet]
        [Route("")]
        public IEnumerable<TeacherModel> GetAll()
        {
            return _teacherFactory.GetAll();
        }

        // GET: api/Teacher/5
        [HttpGet()]
        [Route("{id}")]
        public TeacherModel Get(int id)
        {
            return _teacherFactory.GetOne(id);
        }

        // POST: api/Teacher
        [HttpPost]
        [Route("")]
        public void Post([FromBody] TeacherModel value)
        {
        }

        // PUT: api/Teacher/5
        [HttpPut]
        [Route("{id}")]
        public TeacherModel Put(int id, [FromBody] TeacherModel teacher)
        {
            return _teacherFactory.Update(teacher);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete()]
        [Route("{id}")]
        public void Delete(int id)
        {
            _teacherFactory.Delete(id);
        }
    }
}
