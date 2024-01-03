using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	/// <summary>
	/// Kasa İşlemleri Burada Tutulacak
	/// </summary>
	public class MoneyCase
	{
        public int MoneyCaseID { get; set; }
		/// <summary>
		/// Toplam Tutar
		/// </summary>
		public decimal TotalAmount { get; set; }
    }
}
