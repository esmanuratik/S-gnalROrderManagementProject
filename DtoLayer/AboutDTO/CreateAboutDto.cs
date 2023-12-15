using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.AboutDTO
{
    /// <summary>
    /// Ekleme işlemi gerçekleşecek
    /// </summary>
    public class CreateAboutDto
    {
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
