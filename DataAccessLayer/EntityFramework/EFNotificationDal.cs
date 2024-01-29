using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EFNotificationDal : GenericRepository<Notification>, INotificationDal
	{
		public EFNotificationDal(SignalRContext context) : base(context)
		{
		}

		public List<Notification> GetAllNotificationListByFalse()
		{
			using var context = new SignalRContext();
			return context.Notifications.Where(x=>x.Status==false).ToList();
		}

        public void NotificationChangeToFalse(int id)
        {
            using var context = new SignalRContext();
            var value = context.Notifications.Find(id);
            value.Status = false;
            context.SaveChanges();
        }

        public void NotificationChangeToTrue(int id)
        {
            using var context=new SignalRContext();
			var value = context.Notifications.Find(id);
			value.Status = true;
			context.SaveChanges();
        }

        /// <summary>
        /// Durumu okunmadı olan bildirimler için yazılan metot
        /// </summary>
        /// <returns></returns>
        public int NotificationCountByStatusFalse()
		{
			using var context=new SignalRContext();
			return context.Notifications.Where(x=>x.Status==false).Count();
		}
	}
}
