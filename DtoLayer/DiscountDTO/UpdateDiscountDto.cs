using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DiscountDTO
{
    public class UpdateDiscountDto
    {
        /// <summary>
        /// Günün İndirimleri
        /// </summary>
        public int DiscountID { get; set; }
        /// <summary>
        /// İndirim yapılacak ürün başlığı
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// İndirim miktarı
        /// </summary>
        public string Amount { get; set; }
        /// <summary>
        /// İndirim tanımı
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Ürün Fotoğrafı
        /// </summary>
        public string ImageUrl { get; set; }
		/// <summary>
		/// Aktif Pasif Durumu
		/// </summary>
		public bool Status { get; set; }
	}
}
