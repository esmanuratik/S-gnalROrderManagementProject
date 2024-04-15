using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDiscountService: IGenericService<Discount>
    {
		void ChangeStatusToTrueAsync(int id);
		void ChangeStatusToFalseAsync(int id);
		/// <summary>
		/// Durumu True Olanları Getiren Metot
		/// </summary>
		/// <returns></returns>
		List<Discount> GetListByStatusTrueAsync();
	}
}
