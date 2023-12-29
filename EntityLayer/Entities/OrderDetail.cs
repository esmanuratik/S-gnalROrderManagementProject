using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{

	/// <summary>
	/// Sipariş Detayları 
	/// </summary>
	public class OrderDetail
	{
        /// <summary>
        /// Sipariş Detayları ID
        /// </summary>
        public int OrderDetailID { get; set; }
        /// <summary>
        /// Ürün ID si
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// Ürün
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// Sipariş Sayısı
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Birim Fiyat
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// Toplam Fiyat
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// Sİpariş ID
        /// </summary>
        public int OrderID { get; set; }
        /// <summary>
        /// Sipariş
        /// </summary>
        public Order Order { get; set; }

    }
}
