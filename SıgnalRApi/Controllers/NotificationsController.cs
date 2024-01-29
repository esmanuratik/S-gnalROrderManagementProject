using BusinessLayer.Abstract;
using DtoLayer.NotificationDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SıgnalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationsController : ControllerBase
	{
		private readonly INotificationService _notificationService;

		public NotificationsController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}
		[HttpGet]
		public IActionResult NotificationList()
		{
			return Ok(_notificationService.GetListAllAsync());
		}

		/// <summary>
		/// Okunmamış Olan Bildirim Sayısı
		/// </summary>
		/// <returns></returns>
		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatus()
		{
			return Ok(_notificationService.NotificationCountByStatusFalseAsync());
		}
		[HttpGet("GetAllNotificationListByFalse")]
		public IActionResult GetAllNotificationListByFalse()
		{
			return Ok(_notificationService.GetAllNotificationListByFalseAsync());
		}
		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
		{
			Notification notification = new Notification()
			{
				Description = createNotificationDto.Description,
				Icon = createNotificationDto.Icon,
				Status = createNotificationDto.Status,
				Type = createNotificationDto.Type,
				Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),

			};
			_notificationService.AddAsync(notification);
			return Ok("Ekleme işlemi başarıyla yapıldı.");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteNotification(int id)
		{
			var value=_notificationService.GetByIdAsync(id);
			_notificationService.DeleteAsync(value);
			return Ok("Bildirim Silinmiştir.");
		}
		[HttpGet("{id}")]
		public IActionResult GetNotification(int id)
		{
			var value=_notificationService.GetByIdAsync(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			Notification notification = new Notification()
			{
				NotificationID = updateNotificationDto.NotificationID,
				Description = updateNotificationDto.Description,
				Icon = updateNotificationDto.Icon,
				Status = updateNotificationDto.Status,
				Type = updateNotificationDto.Type,
				Date=updateNotificationDto.Date,
			};
			_notificationService.UpdateAsync(notification);
			return Ok("Güncelleme işlemi başarıyla yapıldı.");
		}
		[HttpGet("NotificationChangeToTrue/{id}")]
		public IActionResult NotificationChangeToTrue(int id)
		{
			_notificationService.NotificationChangeToTrueAsync(id);
			return Ok("Güncelleme Yapıldı");
		}

        [HttpGet("NotificationChangeToFalse/{id}")]
        public IActionResult NotificationChangeToFalse(int id)
        {
            _notificationService.NotificationChangeToFalseAsync(id);
            return Ok("Güncelleme Yapıldı");
        }

    }
}
