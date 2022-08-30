using ChatApp.Application.services.interfaces;
using ChatApp.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var message = _messageService.GetAll();
            return Ok(message);
        }
        [HttpGet]
        public IActionResult ReceivedMessageByUser(string userId)
        {
            var message = _messageService.GetReceivedMessages(userId);
            return Ok(message);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessageTo([FromBody] Message model)
        {

            if (!ModelState.IsValid || model == null)
            {
                return BadRequest(new { message = "User Registration faild" });
            }
            var message = new Message
            {
                Sender = model.Sender,
                Receiver = model.Receiver,
                Created = model.Created,
                MessageContent = model.MessageContent,
                IsDeletedSender = model.IsDeletedSender,
            };
            var result = await _messageService.AddMessageAsync(model);
            return Ok(result);
        }

    }
}
