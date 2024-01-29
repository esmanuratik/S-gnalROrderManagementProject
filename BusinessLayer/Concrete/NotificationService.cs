using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class NotificationService : INotificationService
	{
		private readonly INotificationDal _notificationDal;

		public NotificationService(INotificationDal notificationDal)
		{
			_notificationDal = notificationDal;
		}

		public void AddAsync(Notification entity)
		{
			_notificationDal.Add(entity);
		}

		public void DeleteAsync(Notification entity)
		{
			_notificationDal.Delete(entity);	
		}

		public List<Notification> GetAllNotificationListByFalseAsync()
		{
			return _notificationDal.GetAllNotificationListByFalse();
		}

		public Notification GetByIdAsync(int id)
		{
			return _notificationDal.GetById(id);
		}

		public List<Notification> GetListAllAsync()
		{
			return _notificationDal.GetListAll();
		}

        public void NotificationChangeToFalseAsync(int id)
        {
            _notificationDal.NotificationChangeToFalse(id);
        }

        public void NotificationChangeToTrueAsync(int id)
        {
            _notificationDal.NotificationChangeToTrue(id);
        }

        public int NotificationCountByStatusFalseAsync()
		{
			return _notificationDal.NotificationCountByStatusFalse();
		}

		public void UpdateAsync(Notification entity)
		{
			_notificationDal.Update(entity);
		}
	}
}
