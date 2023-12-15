using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.BookingDTO
{
    /// <summary>
    /// Rezervasyonları ekleme burada tutulacak
    /// </summary>
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
