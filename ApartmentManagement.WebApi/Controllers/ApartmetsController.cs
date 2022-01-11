using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentManagement.Business.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApartmentManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmetsController : ControllerBase
    {
        private IApartmentService _apartmentManager;

        public ApartmetsController(IApartmentService apartmentManager)
        {
            _apartmentManager = apartmentManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_apartmentManager.GetAll());
        }

        // GET api/<ApartmetsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApartmetsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApartmetsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApartmetsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
