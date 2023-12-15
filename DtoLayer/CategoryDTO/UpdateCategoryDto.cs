using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.CategoryDTO
{
    public class UpdateCategoryDto
    {
        /// <summary>
        /// Category ID si
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// Category Adı
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// Category Durumu
        /// </summary>
        public bool CategoryStatus { get; set; }
    }
}
