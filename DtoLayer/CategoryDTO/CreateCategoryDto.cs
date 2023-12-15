using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.CategoryDTO
{
    public class CreateCategoryDto
    {
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
