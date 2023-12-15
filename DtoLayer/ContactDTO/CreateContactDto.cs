using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.ContactDTO
{
    public class CreateContactDto
    {
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
