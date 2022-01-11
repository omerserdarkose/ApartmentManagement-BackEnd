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
    public class UserMessagesController : ControllerBase
    {
        private IUserMessageService _userMessageManager;

        public UserMessagesController(IUserMessageService userMessageManager)
        {
            _userMessageManager = userMessageManager;
        }

        // GET: api/<UserMessagesController>
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

        // GET api/<UserMessagesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserMessagesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserMessagesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserMessagesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
