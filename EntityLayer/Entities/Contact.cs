namespace EntityLayer.Entities
{
    /// <summary>
    /// İletişim ID si
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// İletişim Id si
        /// </summary>
        public int ContactID { get; set; }
        /// <summary>
        /// Konum Bilgisi
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Telefon Numarası
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Mail Adresi
        /// </summary>
        public string MailAddress { get; set; }
        /// <summary>
        /// footer Açıklama Bölümü
        /// </summary>
        public string FooterDescription { get; set; }

    }
}
