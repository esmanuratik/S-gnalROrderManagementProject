using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	/// <summary>
	/// Bildirimler
	/// </summary>
	public class Notification
	{
		public int NotificationID { get; set; }
		/// <summary>
		/// Bildirim Tipi
		/// </summary>
		public string Type { get; set; }
		/// <summary>
		/// Bildirim İkonu
		/// </summary>
		public string Icon { get; set; }
		/// <summary>
		/// Bildirim Açıklaması
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// Bildirim Zamanı
		/// </summary>
		public DateTime Date { get; set; }
		/// <summary>
		/// Bildirim Durumu(Okundu okunmadı durumu)
		/// </summary>
		public bool Status { get; set; }
	}
}
