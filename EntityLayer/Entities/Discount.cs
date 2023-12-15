namespace SıgnalRApi.DAL.Entities
{
    /// <summary>
/// Günün İndirimleri
/// </summary>
    public class Discount
    {
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
    }
}
