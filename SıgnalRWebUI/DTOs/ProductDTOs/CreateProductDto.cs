﻿namespace SıgnalRWebUI.DTOs.ProductDTOs
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
        public int CategoryID { get; set; }
    }
}
