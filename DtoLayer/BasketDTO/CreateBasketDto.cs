using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.BasketDTO
{
    public class CreateBasketDto
    {
        /// <summary>
        /// Fiyat
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Ürün Sayısı
        /// </summary>
        public decimal Count { get; set; }
        /// <summary>
        /// Toplam Fiyat
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// Ürün Id sine göre diğer özellikleri çekeceğim.
        /// </summary>
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }

    }
}
