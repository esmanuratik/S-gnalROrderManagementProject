using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	/// <summary>
	/// Siparişler Burada Tutulacak
	/// </summary>
	public class Order
	{
		/// <summary>
		/// Sipariş Id si
		/// </summary>
        public int OrderID { get; set; }
		/// <summary>
		/// MAsa Numarası
		/// </summary>
        public string TableNumber { get; set; }
		/// <summary>
		/// Sipariş Açıklaması
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// Sipariş Tarihi
		/// </summary>
		public DateTime Date { get; set; }
		/// <summary>
		/// Toplam Fiyat
		/// </summary>
		public decimal TotalPrice { get; set; }//Toplam fiyatı alırken bir tetikleyici kullanılacak
		/// <summary>
		/// Siparişlerin sipariş detayları olur.
		/// </summary>
		public List<OrderDetail> OrderDetails { get; set; }

    }
}
