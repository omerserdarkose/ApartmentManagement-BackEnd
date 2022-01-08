using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Entities.Dtos.UserDetail;

namespace ApartmentManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private IUserDetailService _userDetailManager;

        public UserDetailsController(IUserDetailService userDetailManager)
        {
            _userDetailManager = userDetailManager;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _userDetailManager.GetById(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }


        [HttpPost]
        public IActionResult Add([FromBody] UserDetailAddDto userDetailAddDto)
        {
            var result = _userDetailManager.Add(userDetailAddDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }


        [HttpPut]
        public IActionResult Update([FromBody] UserDetailUpdateDto userDetailUpdateDto)
        {
            var result = _userDetailManager.Update(userDetailUpdateDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _userDetailManager.Delete(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }
    }
}
