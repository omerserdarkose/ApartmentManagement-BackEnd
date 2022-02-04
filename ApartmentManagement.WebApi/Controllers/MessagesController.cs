using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Entities.Dtos.Message;


namespace ApartmentManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private IMessageService _messageManager;

        public MessagesController(IMessageService messageManager)
        {
            _messageManager = messageManager;
        }

        [HttpGet("{id}")]
        public IActionResult GetMessageById(int id)
        {
            return Ok(_messageManager.GetMessageById(id));
        }

        [HttpPost("new-mass")]
        public IActionResult SendMessageToAll(MessageAddDto newMessageAdd)
        {
            return Ok(_messageManager.SendMessageToAll(newMessageAdd));
        }

        [HttpPost("new")]
        public IActionResult SendMessageToOne(MessageAddForOneDto newMessageAddForOne)
        {
            return Ok(_messageManager.SendMessageToOne(newMessageAddForOne));
        }



    }
}
