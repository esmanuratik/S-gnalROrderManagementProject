namespace SıgnalRWebUI.DTOs.BasketDTOs
{
    public class ResultBasketDto
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

        /// <summary>
        /// Ürün ID
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// Bu sepetin bilgileri hangi masaya ait
        /// </summary>
        public int MenuTableID { get; set; }
        public string ProductName { get; set; } 

    }
}
