namespace SıgnalRApi.DAL.Entities
{
    /// <summary>
    /// Ürünler burada tutulacak
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Ürün ID si
        /// </summary>
        public int ProductID { get; set; }
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


        //Tablo İlişkileri


        //Her ürünün kategorisi olur 
        public int CategoryID { get; set; }
        //Bire çok ilişki olduğunu belirtmek için de 
        public Category Category { get; set; }
    }
}
