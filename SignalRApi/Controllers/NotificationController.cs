using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.AboutDTO;
using SignalR.DTOLayer.NotificationDTO;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpGet]
        public IActionResult NotificationList()
        {
            return Ok(_notificationService.TGetListAll());
        }
        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }
        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalse()
        {
            return Ok(_notificationService.TGetAllNotificationByFalse());
        }
        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDTO createNotificationDTO)
        {
            Notification notification = new Notification()
            {
                NotificationDescription = createNotificationDTO.NotificationDescription,
                NotificationIcon = createNotificationDTO.NotificationIcon,
                NotificationType = createNotificationDTO.NotificationType,
                NotificationDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                NotificationStatus = false
            };
            _notificationService.TAdd(notification);
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpDelete("id")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetByID(id);
            _notificationService.TDelete(value);
            return Ok("Bildirim Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDTO updateNotificationDTO)
        {
            Notification notification = new Notification()
            {
                NotificationID = updateNotificationDTO.NotificationID,
                NotificationDescription = updateNotificationDTO.NotificationDescription,
                NotificationIcon = updateNotificationDTO.NotificationIcon,
                NotificationType = updateNotificationDTO.NotificationType,
                NotificationDate = updateNotificationDTO.NotificationDate,
                NotificationStatus = updateNotificationDTO.NotificationStatus
            };
            _notificationService.TUpdate(notification);
            return Ok("Bildirim Güncellendi");
        }
        [HttpGet("NotificationStatusChangeToFalse/{id}")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            _notificationService.TNotificationStatusChangeToFalse(id);
            return Ok("Güncelleme Yapıldı");
        }
        [HttpGet("NotificationStatusChangeToTrue/{id}")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            _notificationService.TNotificationStatusChangeToTrue(id);
            return Ok("Güncelleme Yapıldı");
        }
    }
}
