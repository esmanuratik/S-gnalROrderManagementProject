using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class SocialMedia
    {
        /// <summary>
        /// Sosyal Medya ID si
        /// </summary>
        public int SocialMediaID { get; set; }
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
