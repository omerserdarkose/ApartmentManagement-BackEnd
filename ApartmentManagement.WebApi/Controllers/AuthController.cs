using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Business.Constant;
using ApartmentManagement.Core.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.User;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApartmentManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authManager;
        private IMapper _mapper;

        public AuthController(IAuthService authManager, IMapper mapper)
        {
            _authManager = authManager;
            _mapper = mapper;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] UserForLoginDto userForLogin)
        {
            var loginUser = _authManager.Login(userForLogin);

            if (!loginUser.Success)
            {
                return BadRequest(loginUser.Message);
            }

            var token = _authManager.CreateAccessToken(_mapper.Map<User>(loginUser.Data));

            return Ok(token);
        }
    }
}
