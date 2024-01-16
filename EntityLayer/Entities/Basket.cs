using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    /// <summary>
    /// Sepet
    /// </summary>
    public class Basket
    {
        /// <summary>
        /// Sepet ID
        /// </summary>
        public int BasketID { get; set; }
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


        //İlişkili Tablolar

        /// <summary>
        /// Ürün ID
        /// </summary>
        public int ProductID { get; set; }
        public Product Product { get; set; }//Product sınıfı içerinde de bunu belirt

        /// <summary>
        /// Bu sepetin bilgileri hangi masaya ait
        /// </summary>
        public int MenuTableID { get; set; }
        public MenuTable MenuTable { get; set; }  //MenuTable sınıfı içerisinde de bunu belirt

        
    }
}
