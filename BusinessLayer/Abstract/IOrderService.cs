using EntityLayer.Entities;
using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IOrderService: IGenericService<Order>
	{
		int TotalOrderCountAsync();
		int ActiveOrderCountAsync();
		decimal LastOrderPriceAsync();
		decimal TodayTotalPriceAsync();
	}
}
