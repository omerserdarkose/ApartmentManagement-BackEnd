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


        [HttpPost("mass-message")]
        public IActionResult AddMassMessage([FromBody] UserMessageSendToAllDto value)
        {
            return Ok(_userMessageManager.AddMessageForAll(value));
        }

        [HttpPost("new-message")]
        public IActionResult AddNewMessage([FromBody] UserMessageSendToOneDto value)
        {
            return Ok(_userMessageManager.AddMessageForOne(value));
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
