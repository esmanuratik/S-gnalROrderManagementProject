using EntityLayer.Entities;
using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface INotificationDal: IGenericDal<Notification>
	{
		/// <summary>
		/// Durumu okunmadı olan bildirimler için yazılan metot
		/// </summary>
		/// <returns></returns>
		int NotificationCountByStatusFalse();
		List<Notification> GetAllNotificationListByFalse();
		void NotificationChangeToTrue(int id);
		void NotificationChangeToFalse(int id);
	}
}
