using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Entities.Dtos.UserMessage;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApartmentManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessagesController : ControllerBase
    {
        private IUserMessageService _userMessageManager;

        public UserMessagesController(IUserMessageService userMessageManager)
        {
            _userMessageManager = userMessageManager;
        }

 
        [HttpGet("inbox")]
        public IActionResult GetIncomingMessages()
        {
            return Ok(_userMessageManager.GetUserIncomingMessages());
        }

        [HttpGet("sent")]
        public IActionResult GetSentMessages()
        {
            return Ok(_userMessageManager.GetUserSentMessages());
        }


        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPut("{id:int}&status={status:bool}")]
        public IActionResult UpdateReadStatus(int id,bool status)
        {
            return Ok(_userMessageManager.UpdateReadStatus(id,status));
        }


        [HttpDelete("{id}&isSender={isSender:bool}")]
        public IActionResult Delete(int id,bool isSender)
        {
            var result = _userMessageManager.Delete(id, isSender);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
