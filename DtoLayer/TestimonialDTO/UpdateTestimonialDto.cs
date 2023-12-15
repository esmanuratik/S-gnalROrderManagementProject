using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.TestimonialDTO
{
    /// <summary>
    /// Referansların güncelleneceği dto
    /// </summary>
    public class UpdateTestimonialDto
    {
        /// <summary>
        /// Referans ID si
        /// </summary>
        public int TestimonialID { get; set; }
        /// <summary>
        /// Referans Adı
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Referans Başlığı
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Referans Yorumu
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Referans Resmi
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// Referans Durumu
        /// </summary>
        public bool Status { get; set; }
    }
}

