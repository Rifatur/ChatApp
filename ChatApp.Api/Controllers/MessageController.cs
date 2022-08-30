using ChatApp.Application.services.interfaces;
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

        public IActionResult ReceivedMessageByUser(string userId)
        {
            var message = _messageService.GetReceivedMessages(userId);
            return Ok(message);
        }

    }
}
