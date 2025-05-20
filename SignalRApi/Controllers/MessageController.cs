using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.AboutDTO;
using SignalR.DTOLayer.MessageDTO;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateMessageDTO createMessageDTO)
        {
            Message message = new Message()
            {
                MessageMail = createMessageDTO.MessageMail,
                MessageContent = createMessageDTO.MessageContent,
                MessageSendDate = DateTime.Now,
                MessageFullName = createMessageDTO.MessageFullName,
                MessagePhoneNumber = createMessageDTO.MessagePhoneNumber,
                MessageStatus = false,
                MessageSubject = createMessageDTO.MessageSubject,
            };
            _messageService.TAdd(message);
            return Ok("Mesaj Başarıyla Gönderildi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetByID(id);
            _messageService.TDelete(value);
            return Ok("Mesaj Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetByID(id);
            return Ok(value);
        }
    }
}
