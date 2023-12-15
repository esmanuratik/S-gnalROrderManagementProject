using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.ProductDTO
{
    /// <summary>
    /// Ürünleri ekleme işlemi yapacak dto
    /// </summary>
    public class CreateProductDto
    {
        /// <summary>
        /// Ürün Adı
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Ürün Açıklaması
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Ürün FiyatıÜrün Fiyatı
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Ürün Fotoğrafı
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// Ürün Durumu
        /// </summary>
        public bool ProductStatus { get; set; }
    }
}
