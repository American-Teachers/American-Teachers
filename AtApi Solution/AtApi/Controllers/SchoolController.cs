using AtApi.Model;
using AtApi.Model.At;
using AtApi.Service;
using AtApi.Service.Factory;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {

        private readonly IFactory<School> factory;
        public SchoolController(IFactory<School> factory)
        {
            this.factory = factory;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<School>>> GetAllAsync()
        {
            return await factory.GetAllAsync().ConfigureAwait(false);
        }


        [HttpGet()]
        [Route("{id}")]
        public async Task<ActionResult<School>> GetClassAsync(int id)
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
        public async Task<ActionResult<School>> PostClass([FromBody] School model)
        {
            return await factory.CreateAsync(model);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<School>> PutClassModelAsync(int id, [FromBody] School model)
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