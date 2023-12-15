namespace SıgnalRApi.DAL.Entities
{
    /// <summary>
    /// Ürün Hakkında
    /// </summary>
    public class About
    {
        /// <summary>
        /// Hakkında Id si
        /// </summary>
        public int AboutID { get; set; }
        /// <summary>
        /// Ürün Fotoğrafı
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// Hakkında Başlığı
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Hakkında açıklama kısmı
        /// </summary>
        public string Description { get; set; }

    }
}
 