using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SıgnalRWebUI.DTOs.SocialMediaDTOs
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
