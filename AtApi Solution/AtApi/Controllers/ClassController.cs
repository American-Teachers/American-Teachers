using AtApi.Extensions;
using AtApi.Framework;
using AtApi.Models.AccountViewModels;
using AtApi.Service;
using AtApi.Service.Identity;
using AtApi.Model.At;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {

        private readonly IFactory<Class> factory;
        private readonly IFactory<Enrollment> enrollmentFactory;
        public ClassController(IFactory<Class> factory)
        {
            this.factory = factory;
        }
        
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Class>>> GetAllAsync()
        {
            return await factory.GetAllAsync().ConfigureAwait(false);
        }

         
        [HttpGet()]
        [Route("{id}")]
        public async Task<ActionResult<Class>> GetClassAsync(int id)
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
        public async Task<ActionResult<Class>> PostClass([FromBody] Class model)
        {
            return await factory.CreateAsync(model);
        }

       
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Class>> PutClassModelAsync(int id, [FromBody] Class model)
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

        [HttpGet()]
        [Route("{id}/Enrollment")]
        public async Task<ActionResult<Class>> GetClassEnrollmentAsync(int id)
        {
            var item = await factory.GetOneAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
    }
}