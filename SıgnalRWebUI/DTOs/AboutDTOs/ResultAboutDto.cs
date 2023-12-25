using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SıgnalRWebUI.DTOs.AboutDTOs
{
    /// <summary>
    /// Burada ürünlerin hakkında kısmını listeleme işleme yapılacak ve bundan dolayı bütün propertylerin bulunması gerekiyordu.
    /// </summary>
    public class ResultAboutDto
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
