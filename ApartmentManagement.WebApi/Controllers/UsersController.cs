using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Entities.Dtos.User;

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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userManager.GetAll());
        }


        [HttpPost]
        public IActionResult Add([FromBody] UserAddWithDetailsDto newUser)
        {
            var result = _userManager.AddWithDetails(newUser);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }


        [HttpPut]
        public IActionResult Update([FromBody] UserUpdateDto userUpdateInfo)
        {
            var result = _userManager.Update(userUpdateInfo);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int userId)
        {
            var result=_userManager.Delete(userId);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpPost("{id}")]
        public IActionResult PasswordReset(int userId)
        {
            var passReset = _userManager.PasswordReset(userId);

            if (!passReset.Success)
            {
                return BadRequest(passReset.Message);
            }

            return Ok(passReset.Message);
        }
    }
}
