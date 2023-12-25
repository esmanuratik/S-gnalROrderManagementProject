﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SıgnalRWebUI.DTOs.FeatureDTOs
{
    /// <summary>
    /// Öne Çıkanlar burada güncellenecek
    /// 3 kısımdan oluşacak onun için ayrı ayrı 3 tane title ve description oluşturdum.
    /// </summary>
    public class UpdateFeatureDto
    {
        public int FeatureID { get; set; }
        public string Title1 { get; set; }
        public string Description1 { get; set; }
        public string Title2 { get; set; }
        public string Description2 { get; set; }
        public string Title3 { get; set; }
        public string Description3 { get; set; }
    }
}
