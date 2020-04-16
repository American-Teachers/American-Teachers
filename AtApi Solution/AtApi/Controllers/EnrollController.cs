using AtApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace AtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollController : ControllerBase
    {
        // GET: api/Student/5
        [HttpPut]
        [Route("")]
        public string Post(Enrollment enrollModel)
        {
            return "value";
        }

    }
}
