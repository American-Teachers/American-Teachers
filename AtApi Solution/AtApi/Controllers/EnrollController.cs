using AtApi.Model;
using AtApi.Model.At;
using AtApi.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollController : ControllerBase
    {
        private readonly IFactory<Enrollment> factory;

        public EnrollController(IFactory<Enrollment> factory)
        {
            this.factory = factory;
        }
        [HttpGet]
        [Route("")]
        public IEnumerable<Enrollment> GetAll()
        {
            return factory.GetAll();
        }

        // GET: api/Enrollment/5
        [HttpGet]
        [Route("{id}")]
        public Enrollment GetClass(int id)
        {
            return factory.GetOne(id);
        }


        [HttpPost]
        [Route("")]
        public Enrollment Post(Enrollment model)
        {
            return factory.Update(model);
        }

        [HttpPut]
        [Route("")]
        public Enrollment Put(Enrollment model)
        {
            return factory.Create(model);
        }

    }
}
