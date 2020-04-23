using AtApi.Model;
using AtApi.Model.At;
using AtApi.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IFactory<Parent> factory;
        public ParentController(IFactory<Parent> factory)
        {
            this.factory = factory;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Parent>>> GetAllAsync()
        {
            return await factory.GetAllAsync().ConfigureAwait(false);
        }


        [HttpGet()]
        [Route("{id}")]
        public async Task<ActionResult<Parent>> GetClassAsync(int id)
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
        public async Task<ActionResult<Parent>> PostClass([FromBody] Parent model)
        {
            return await factory.CreateAsync(model);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Parent>> PutClassModelAsync(int id, [FromBody] Parent model)
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