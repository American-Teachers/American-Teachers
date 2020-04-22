using AtApi.Model;
using AtApi.Model.At;
using AtApi.Service;
using AtApi.Service.Factory;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly IFactory<Teacher> factory;

        public TeacherController(IFactory<Teacher> factory)
        {
            this.factory = factory;
        }


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetAllAsync()
        {
            return await factory.GetAllAsync().ConfigureAwait(false);
        }


        [HttpGet()]
        [Route("{id}")]
        public async Task<ActionResult<Teacher>> GetClassAsync(int id)
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
        public async Task<ActionResult<Teacher>> PostClass([FromBody] Teacher model)
        {
            return await factory.CreateAsync(model);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Teacher>> PutClassModelAsync(int id, [FromBody] Teacher model)
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