using EntityLayer.Entities;
using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface INotificationService: IGenericService<Notification>
	{
		int NotificationCountByStatusFalseAsync();
		List<Notification> GetAllNotificationListByFalseAsync();
        void NotificationChangeToTrueAsync(int id);
        void NotificationChangeToFalseAsync(int id);
    }
}
