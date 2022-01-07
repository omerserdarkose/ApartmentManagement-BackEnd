using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Entities.Dtos.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApartmentManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userManager;

        public UsersController(IUserService userManager)
        {
            _userManager = userManager;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userManager.GetAll());
        }

        // GET api/<UsersController>/5
        [HttpGet("{mail}")]
        public IActionResult Get(string mail)
        {

            return Ok(_userManager.GetByMail(mail));
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Add([FromBody] UserAddDto newUser)
        {
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public void Update([FromBody] UserUpdateDto userUpdate)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
