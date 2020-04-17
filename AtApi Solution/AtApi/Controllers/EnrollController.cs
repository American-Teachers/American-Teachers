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
        private readonly IFactory<Enrollment> _factory;


        [HttpGet]
        [Route("")]
        public IEnumerable<Enrollment> GetAll()
        {
            return _factory.GetAll();
        }

        // GET: api/Enrollment/5
        [HttpGet()]
        [Route("{id}")]
        public Enrollment GetClass(int id)
        {
            return _factory.GetOne(id);
        }


        [HttpPut]
        [Route("")]
        public Enrollment Post(Enrollment model)
        {
            return _factory.Update(model);
        }

        [HttpPut]
        [Route("")]
        public Enrollment Put(Enrollment model)
        {
            return _factory.Create(model);
        }

    }
}
