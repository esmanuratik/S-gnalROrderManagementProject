namespace SıgnalRWebUI.DTOs.BookingDTOs
{
    public class CreateBookingDto
    {
        /// <summary>
        /// Rezervasyon Adı
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Rezervasyon Telefon Numarası
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Rezervasyon Maili
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Rezervasyon Kişi Sayısı
        /// </summary>
        public int PersonCount { get; set; }
        /// <summary>
        /// Rezervasyon oluşturulma tarihi
        /// </summary>
        public DateTime Date { get; set; }
    }
}
