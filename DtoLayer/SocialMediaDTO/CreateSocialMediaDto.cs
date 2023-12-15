using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.SocialMediaDTO
{
    public class CreateSocialMediaDto
    {
        /// <summary>
        /// Sosyal Medya Başlığı
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Sosyal Medya Url
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Sosyal Medya Ikonu
        /// </summary>
        public string Icon { get; set; }
    }
}
