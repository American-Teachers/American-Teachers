using AtApi.Model.At;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AtApi.Service.Factory;
using Microsoft.AspNetCore.Authorization;

namespace AtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EnrollmentController : ControllerBase
    {
        private readonly IFactory<Enrollment> factory;

        public EnrollmentController(IFactory<Enrollment> factory)
        {
            this.factory = factory;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetAllAsync()
        {
            return await factory.GetAllAsync().ConfigureAwait(false);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Enrollment>> GetAsync(int id)
        {
            var item =await factory.GetOneAsync(id).ConfigureAwait(false);
            if (item == null)
            {
                return NotFound();
            }
            return item;

        }


        [HttpPost]
        [Route("{id}")]
        public async Task<ActionResult<Enrollment>> PostAsync(Enrollment model)
        {
            return await factory.CreateAsync(model).ConfigureAwait(false);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Enrollment>> PutAsync(int id, Enrollment model)
        {
            return await factory.UpdateAsync(model).ConfigureAwait(false);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await factory.DeleteAsync(id).ConfigureAwait(false);
            return Ok();
        }
    }
}
