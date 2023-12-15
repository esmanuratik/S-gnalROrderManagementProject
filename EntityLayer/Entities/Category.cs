namespace SıgnalRApi.DAL.Entities
{
    /// <summary>
    /// Ürünlerin kategorileri burada tutulacak
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Category ID si
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// Category Adı
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// Category Durumu
        /// </summary>
        public bool CategoryStatus{ get; set; }



        //Tablo İlişkileri

        //Her ürünün kategorisi vardır kategorininde ürünlerini listelemek gerekir.
        public List<Product> Products { get; set; }
    }
}
