﻿using AtApi.Model.At;
using AtApi.Service.Factory;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IFactory<Student> factory;
        public StudentController(IFactory<Student> factory)
        {
            this.factory = factory;
        }


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllAsync()
        {
            return await factory.GetAllAsync().ConfigureAwait(false);
        }


        [HttpGet()]
        [Route("{id}")]
        public async Task<ActionResult<Student>> GetClassAsync(int id)
        {
            var item = await factory.GetOneAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }


        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Student>> PostClass([FromBody] Student model)
        {
            return await factory.CreateAsync(model);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Student>> PutClassModelAsync(int id, [FromBody] Student model)
        {
            var item = await factory.GetOneAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return await factory.UpdateAsync(model).ConfigureAwait(false);
        }


        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            factory.DeleteAsync(id);
            return Ok();
        }
    }
}