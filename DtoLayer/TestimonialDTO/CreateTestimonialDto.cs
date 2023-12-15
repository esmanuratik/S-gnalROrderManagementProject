using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.TestimonialDTO
{
    /// <summary>
    /// Referansların eklenceği dto
    /// </summary>
    public class CreateTestimonialDto
    {
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

